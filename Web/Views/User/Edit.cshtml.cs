using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Web.Views.User;

/// <summary>
/// For CRUD actions.
/// </summary>
public class UserEditViewModel
{
    [Obsolete("Public parameterless constructor required for model binding.", error: true)]
    public UserEditViewModel() { }

    public UserEditViewModel(Data.Entities.Users.User user)
    {
        User = user;
    }

    [ValidateNever]
    public Data.Entities.Users.User User { get; set; } = null!;

    /// <summary>
    /// If null, user has not yet tried to update.
    /// If true, user has successfully updated.
    /// If false, user failed to update.
    /// </summary>
    public bool? WasUpdated { get; set; }
}
