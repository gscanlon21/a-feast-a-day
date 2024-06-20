
namespace Core.Consts;

/// <summary>
/// Shared user consts for Functions and Web.
/// </summary>
public class NewsletterConsts
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
}
