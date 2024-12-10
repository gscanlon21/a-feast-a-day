﻿using Api.Code;
using Azure;
using Core.Models.Options;
using Data;
using Data.Entities.Newsletter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Api.Services;

public class EmailSenderService(ILogger<EmailSenderService> logger, IOptions<SiteSettings> siteSettings, IOptions<FeatureSettings> featureSettings, IMailSender mailSender, IServiceScopeFactory serviceScopeFactory)
    : BackgroundService
{
    private readonly string From = $"newsletter@{siteSettings.Value.Domain}";

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            logger.Log(LogLevel.Information, "Starting email sender service, {SendEmail}", featureSettings.Value.SendEmail);

            while (featureSettings.Value.SendEmail && !stoppingToken.IsCancellationRequested)
            {
                using var scope = serviceScopeFactory.CreateScope();
                using var context = scope.ServiceProvider.GetRequiredService<CoreContext>();

                UserEmail? nextNewsletter = null;
                try
                {
                    // Not worried about repeat reads, only 1 thread.
                    nextNewsletter = await GetNextNewsletter(context);

                    if (nextNewsletter != null)
                    {
                        nextNewsletter.SendAttempts += 1;
                        nextNewsletter.Status = UserEmail.EmailStatus.Sending;
                        await context.SaveChangesAsync(CancellationToken.None);

                        nextNewsletter.SenderId = await mailSender.SendMail(From, nextNewsletter.User.Email, nextNewsletter.Subject, nextNewsletter.Body, CancellationToken.None);
                        nextNewsletter.Status = UserEmail.EmailStatus.Sent;
                        await context.SaveChangesAsync(CancellationToken.None);
                    }
                    else
                    {
                        // There is no mail to send, wait 10s before retrying.
                        await Task.Delay(10000, stoppingToken);
                    }
                }
                catch (Exception e) when (nextNewsletter != null)
                {
                    nextNewsletter.LastError = e.ToString();
                    nextNewsletter.Status = UserEmail.EmailStatus.Failed;

                    // If the email soft-bounced after the first try, retry.
                    if (nextNewsletter.SendAttempts <= NewsletterConsts.MaxSendAttempts
                        // And the send mail request did not fail with a 5xx status code.
                        && (e is not RequestFailedException requestFailedException || requestFailedException.ErrorCode?.StartsWith('5') != true))
                    {
                        // TODO? Check the Retry-After header from the Catch429Policy response?
                        // There will be other emails sending in the meantime, so that might not be entirely accurate.
                        nextNewsletter.SendAfter = DateTime.UtcNow.AddHours(1);
                        nextNewsletter.Status = UserEmail.EmailStatus.Pending;
                    }

                    await context.SaveChangesAsync(CancellationToken.None);
                }
                catch (Exception e)
                {
                    logger.Log(LogLevel.Error, e, "Error querying emails");

                    // Error querying for new mails, wait a minute before retrying.
                    await Task.Delay(60000, stoppingToken);
                }
                finally
                {
                    // Don't want to spam the email sending server.
                    await Task.Delay(3000, stoppingToken);
                }
            }

            logger.Log(LogLevel.Information, "Stopping email sender service");
        }
        catch (Exception e)
        {
            logger.Log(LogLevel.Error, e, "Email sender service failed");
        }
    }

    internal static async Task<UserEmail?> GetNextNewsletter(CoreContext context)
    {
        return await context.UserEmails
            .Include(un => un.User)
            .OrderBy(un => un.Id)
            .Where(un => un.Date.AddDays(1) >= DateHelpers.Today)
            .Where(un => un.Status == UserEmail.EmailStatus.Pending)
            .Where(un => un.SendAttempts <= NewsletterConsts.MaxSendAttempts)
            .Where(un => DateTime.UtcNow > un.SendAfter)
            .FirstOrDefaultAsync(CancellationToken.None);
    }
}
