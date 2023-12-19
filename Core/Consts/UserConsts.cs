using Core.Models.Exercise;
using Core.Models.Footnote;
using Core.Models.Newsletter;
using Core.Models.User;

namespace Core.Consts;

/// <summary>
/// Shared user consts for Functions and Web.
/// </summary>
public class UserConsts
{
    public const string DemoUser = "demo@afeastaday.com";
    public const string DemoToken = "00000000-0000-0000-0000-000000000000";

    public const int SendHourMin = 0;
    public const int SendHourDefault = 0;
    public const int SendHourMax = 23;

    public const Days DaysDefault = Days.Monday | Days.Tuesday | Days.Thursday | Days.Friday;

    public const Verbosity VerbosityDefault = Verbosity.Instructions
        | Verbosity.Images | Verbosity.ProgressionBar | Verbosity.Proficiency;

    public const FootnoteType FootnotesDefault = FootnoteType.FitnessTips | FootnoteType.FitnessFacts
        | FootnoteType.HealthTips | FootnoteType.HealthFacts | FootnoteType.GoodVibes | FootnoteType.Mindfulness;

    /// <summary>
    /// After how many weeks until muscle targets start taking effect.
    /// </summary>
    public const int MuscleTargetsTakeEffectAfterXWeeks = 1;

    /// <summary>
    /// The lowest the user's progression can go.
    /// 
    /// Also the user's starting progression when the user is new to fitness.
    /// </summary>
    public const int MinUserProgression = 5;

    /// <summary>
    /// Also the user's starting progression when the user is not new to fitness.
    /// </summary>
    public const int MidUserProgression = 50;

    /// <summary>
    /// The highest the user's progression can go.
    /// </summary>
    public const int MaxUserProgression = 95;

    /// <summary>
    /// How many custom user_frequency records do we allow per user?
    /// </summary>
    public const int MaxUserFrequencies = 7;

    /// <summary>
    /// How much to increment the user_muscle_strength target ranges with each increment?
    /// </summary>
    public const int IncrementMuscleTargetBy = 10;

    /// <summary>
    /// How many months until the user's account is disabled for inactivity.
    /// </summary>
    public const int DisableAfterXMonths = 3;

    /// <summary>
    /// How many months until the user's account is deleted for inactivity.
    /// </summary>
    public const int DeleteAfterXMonths = 6;

    /// <summary>
    /// How many months until the user's newsletter logs are deleted.
    /// </summary>
    public const int DeleteLogsAfterXMonths = 12;
}
