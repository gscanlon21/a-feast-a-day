
namespace Web.Views.Shared.Components.BackupRestore;

public class BackupRestoreViewModel
{
    [Obsolete("Public parameterless constructor for model binding.", error: true)]
    public BackupRestoreViewModel() { }

    public BackupRestoreViewModel(Data.Entities.User.User user, string token)
    {
        Token = token;
        Email = user.Email;
    }

    public string Email { get; init; } = null!;
    public string Token { get; init; } = null!;
}
