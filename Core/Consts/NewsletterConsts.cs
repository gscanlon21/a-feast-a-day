
using ADay.Core.Models.Footnote;

namespace Core.Consts;

/// <summary>
/// Shared newsletter consts.
/// </summary>
public static class NewsletterConsts
{
    public const string SubjectLogin = "Account Access";

    public const string SubjectConfirm = "Account Confirmation";

    public const string SubjectFeast = "Daily Feast";

    public const string SubjectException = "Unhandled Exception";

    public const int MaxSendAttempts = 1;

    /// <summary>
    /// How many months until the user's newsletter logs are deleted.
    /// </summary>
    public const int DeleteEmailsAfterXMonths = 1;

    public static readonly FootnoteType[] FootnoteTypes = 
    [
        FootnoteType.Custom, FootnoteType.GoodVibes, FootnoteType.Mindfulness, FootnoteType.HealthFacts, FootnoteType.HealthTips,
        FootnoteType.CookingTips, FootnoteType.CookingAffirmations, FootnoteType.CookingMotivation, FootnoteType.IngredientTips,
    ];
}
