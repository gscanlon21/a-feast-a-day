using Data;
using Microsoft.EntityFrameworkCore;
using Quartz;

namespace Api.Jobs.Update;

/// <summary>
/// Unsubscribes users from the newsletter if sending their emails fails too many times.
/// </summary>
public class EnableSkippedRecipes(ILogger<EnableSkippedRecipes> logger, CoreContext coreContext) : IJob, IScheduled
{
    public async Task Execute(IJobExecutionContext context)
    {
        try
        {
            var skippedRecipes = await coreContext.UserRecipes
                .Where(ur => DateHelpers.Today > ur.IgnoreUntil)
                .IgnoreQueryFilters().ToListAsync();

            foreach (var userRecipe in skippedRecipes)
            {
                userRecipe.IgnoreUntil = null;
            }

            await coreContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            logger.Log(LogLevel.Error, e, "");
        }
    }

    public static JobKey JobKey => new(nameof(EnableSkippedRecipes) + "Job", GroupName);
    public static TriggerKey TriggerKey => new(nameof(EnableSkippedRecipes) + "Trigger", GroupName);
    public static string GroupName => "Update";

    public static async Task Schedule(IScheduler scheduler)
    {
        var job = JobBuilder.Create<EnableSkippedRecipes>()
            .WithIdentity(JobKey)
            .Build();

        // Trigger the job every day.
        var trigger = TriggerBuilder.Create()
            .WithIdentity(TriggerKey)
            .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(0, 0))
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
