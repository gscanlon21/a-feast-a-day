﻿using Core.Code.Helpers;
using Core.Consts;
using Core.Models.Options;
using Core.Models.User;
using Data;
using Data.Entities.Newsletter;
using Data.Entities.User;
using Data.Repos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Quartz;
using System.Net;

namespace Api.Jobs.Create;

[DisallowConcurrentExecution]
public class CreateEmails : IJob, IScheduled
{
    private readonly UserRepo _userRepo;
    private readonly CoreContext _coreContext;
    private readonly HttpClient _httpClient;
    private readonly IOptions<SiteSettings> _siteSettings;
    private readonly ILogger<CreateEmails> _logger;

    public CreateEmails(ILogger<CreateEmails> logger, UserRepo userRepo, IHttpClientFactory httpClientFactory, IOptions<SiteSettings> siteSettings, CoreContext coreContext)
    {
        _logger = logger;
        _userRepo = userRepo;
        _coreContext = coreContext;
        _siteSettings = siteSettings;
        _httpClient = httpClientFactory.CreateClient();
        if (_httpClient.BaseAddress != _siteSettings.Value.WebUri)
        {
            _httpClient.BaseAddress = _siteSettings.Value.WebUri;
        }
    }

    public async Task Execute(IJobExecutionContext context)
    {
        try
        {
            var options = new ParallelOptions() { MaxDegreeOfParallelism = 3, CancellationToken = context.CancellationToken };
            await Parallel.ForEachAsync(await GetUsers(), options, async (user, cancellationToken) =>
            {
                try
                {
                    var token = await _userRepo.AddUserToken(user, durationDays: 100); // Needs to last at least 3 months by law for unsubscribe link.
                    var html = await _httpClient.GetAsync($"/newsletter/{Uri.EscapeDataString(user.Email)}?token={Uri.EscapeDataString(token)}");
                    if (html.StatusCode == HttpStatusCode.OK)
                    {
                        // Insert newsletter record
                        var userNewsletter = new UserEmail(user)
                        {
                            Subject = NewsletterConsts.SubjectFeast,
                            Body = await html.Content.ReadAsStringAsync(cancellationToken),
                        };

                        _coreContext.UserEmails.Add(userNewsletter);
                        await _coreContext.SaveChangesAsync(cancellationToken);
                    }
                    else if (html.StatusCode != HttpStatusCode.NoContent)
                    {
                        _logger.Log(LogLevel.Warning, "Newsletter failed for user {Id} with status {StatusCode}", user.Id, html.StatusCode);
                    }
                }
                catch (Exception e)
                {
                    _logger.Log(LogLevel.Error, e, "Error retrieving newsletter for user {Id}", user.Id);
                }
            });
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, e, "Error running job {p0}", nameof(CreateEmails));
        }
    }

    internal async Task<List<User>> GetUsers()
    {
        var currentDay = DateHelpers.Today.DayOfWeek;
        var currentHour = int.Parse(DateTime.UtcNow.ToString("HH"));
        return await _coreContext.Users
            // User has confirmed their account.
            .Where(u => u.LastActive.HasValue)
            // User is subscribed to the newsletter.
            .Where(u => u.NewsletterDisabledReason == null)
            // User's send time is now.
            .Where(u => u.SendHour == currentHour)
            // User's send day is now or user is the Debug user-send emails every day.
            .Where(u => u.SendDay == currentDay || u.Features.HasFlag(Features.Debug))
            // User has not received an email today.
            .Where(u => !u.UserEmails.Where(un => un.Subject == NewsletterConsts.SubjectFeast).Any(un => un.Date == DateHelpers.Today))
            // User is not a test or demo user.
            .Where(u => !u.Email.EndsWith(_siteSettings.Value.Domain) || u.Features.HasFlag(Features.Test) || u.Features.HasFlag(Features.Debug))
            .ToListAsync();
    }

    public static JobKey JobKey => new(nameof(CreateEmails) + "Job", GroupName);
    public static TriggerKey TriggerKey => new(nameof(CreateEmails) + "Trigger", GroupName);
    public static string GroupName => "Create";

    public static async Task Schedule(IScheduler scheduler)
    {
        var job = JobBuilder.Create<CreateEmails>()
            .WithIdentity(JobKey)
            .Build();

        var trigger = TriggerBuilder.Create()
            .WithIdentity(TriggerKey)
            // https://www.freeformatter.com/cron-expression-generator-quartz.html
            .WithCronSchedule("0 0,30,45,55,59 * ? * * *")
            .Build();

        if (await scheduler.GetTrigger(trigger.Key) != null)
        {
            // Update
            await scheduler.RescheduleJob(trigger.Key, trigger);
        }
        else
        {
            // Create
            await scheduler.ScheduleJob(job, trigger);
        }
    }
}
