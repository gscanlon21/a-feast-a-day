using Data;
using Microsoft.EntityFrameworkCore;
using Quartz;

namespace Api.Jobs.Delete;

public class DeleteOldFeasts(ILogger<DeleteOldFeasts> logger, CoreContext coreContext) : IJob, IScheduled
{
    public async ValueTask Execute(IJobExecutionContext context, CancellationToken cancellationToken = default)
    {
        try
        {
            await coreContext.UserFeasts.IgnoreQueryFilters()
                .Where(u => u.Date < DateHelpers.Today.AddMonths(-1 * UserConsts.DeleteFeastsAfterXMonths))
                .ExecuteDeleteAsync();
        }
        catch (Exception e)
        {
            logger.Log(LogLevel.Error, e, "");
        }
    }

    public static JobKey JobKey => new(nameof(DeleteOldFeasts) + "Job", GroupName);
    public static TriggerKey TriggerKey => new(nameof(DeleteOldFeasts) + "Trigger", GroupName);
    public static string GroupName => "Delete";

    public static async Task Schedule(IScheduler scheduler)
    {
        var job = JobBuilder.Create<DeleteOldFeasts>()
            .WithIdentity(JobKey)
            .Build();

        // Trigger the job every day
        var trigger = TriggerBuilder.Create()
            .WithIdentity(TriggerKey)
            .WithSchedule(CronScheduleBuilder.Create(new CronExpression("0 0 0 * * ?")))
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
