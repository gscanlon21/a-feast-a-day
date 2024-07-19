using Core.Code.Helpers;
using Core.Models.Options;
using Core.Models.User;
using Data;
using Data.Entities.User;
using Data.Repos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Quartz;

namespace Api.Jobs.Create;

/// <summary>
/// Creates a new feast for app users, so the nutrient targets are up-to-date if the user doesn't check the app every day.
/// </summary>
[DisallowConcurrentExecution]
public class CreateFeasts : IJob, IScheduled
{
    private readonly UserRepo _userRepo;
    private readonly HttpClient _httpClient;
    private readonly CoreContext _coreContext;
    private readonly ILogger<CreateFeasts> _logger;
    private readonly IOptions<SiteSettings> _siteSettings;

    public CreateFeasts(ILogger<CreateFeasts> logger, UserRepo userRepo, IHttpClientFactory httpClientFactory, IOptions<SiteSettings> siteSettings, CoreContext coreContext)
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
            _logger.Log(LogLevel.Information, "Starting job {p0}", nameof(CreateFeasts));
            var options = new ParallelOptions() { MaxDegreeOfParallelism = 3, CancellationToken = context.CancellationToken };
            await Parallel.ForEachAsync(await GetUsers(), options, async (userToken, cancellationToken) =>
            {
                try
                {
                    // Don't hit the user repo because we're in a parallel loop and CoreContext isn't thread-safe.
                    await _httpClient.GetAsync($"/newsletter/{Uri.EscapeDataString(userToken.User.Email)}?token={Uri.EscapeDataString(userToken.Token)}", cancellationToken);
                }
                catch (Exception e)
                {
                    _logger.Log(LogLevel.Error, e, "Error retrieving newsletter for user {Id}", userToken.User.Id);
                }
            });
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, e, "Error running job {p0}", nameof(CreateFeasts));
        }
    }

    internal async Task<IEnumerable<(User User, string Token)>> GetUsers()
    {
        var currentDay = DateHelpers.Today.DayOfWeek;
        var currentHour = int.Parse(DateTime.UtcNow.ToString("HH"));
        return await Task.WhenAll((await _coreContext.Users
            // User has confirmed their account.
            .Where(u => u.LastActive.HasValue)
            // User is not subscribed to the newsletter.
            .Where(u => u.NewsletterDisabledReason != null)
            // User's send time is now.
            .Where(u => u.SendHour == currentHour)
            // User's send day is now or user is the Debug user-send emails every day.
            .Where(u => u.SendDay == currentDay || u.Features.HasFlag(Features.Debug))
            // User is not a test or demo user.
            .Where(u => !u.Email.EndsWith(_siteSettings.Value.Domain) || u.Features.HasFlag(Features.Test) || u.Features.HasFlag(Features.Debug))
            .ToListAsync())
            // Token needs to last at least 3 months by law for unsubscribe link.
            .Select(async u => (u, await _userRepo.AddUserToken(u, durationDays: 100))));
    }

    public static JobKey JobKey => new(nameof(CreateFeasts) + "Job", GroupName);
    public static TriggerKey TriggerKey => new(nameof(CreateFeasts) + "Trigger", GroupName);
    public static string GroupName => "Create";

    public static async Task Schedule(IScheduler scheduler)
    {
        var job = JobBuilder.Create<CreateFeasts>()
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
