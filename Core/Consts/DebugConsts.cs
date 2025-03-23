namespace Core.Consts;

/// <summary>
/// Debug consts. Useful for attribute parameters.
/// </summary>
public static class DebugConsts
{
#if DEBUG
    public const bool IsDebug = true;
#else
    public const bool IsDebug = false;
#endif

    /// <summary>
    /// Days of the week to send the debug newsletter.
    /// </summary>
    public static readonly DayOfWeek[] DebugDays = [DayOfWeek.Friday, DayOfWeek.Saturday, DayOfWeek.Sunday];
}
