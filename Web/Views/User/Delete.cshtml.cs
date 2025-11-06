using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using Web.Views.Index;

namespace Web.Views.User;

public class DeleteViewModel
{
    [Obsolete("Public parameterless constructor required for model binding.", error: true)]
    public DeleteViewModel() { }

    public DeleteViewModel(Data.Entities.Users.User user, string token)
    {
        User = user;
        Token = token;
        Email = user.Email;
    }

    [ValidateNever]
    public Data.Entities.Users.User User { get; set; } = null!;

    public string Token { get; set; } = null!;

    /// <summary>
    /// If null, user has not yet tried to update.
    /// If true, user has successfully updated.
    /// If false, user failed to update.
    /// </summary>
    public bool? WasUpdated { get; set; }

    [DataType(DataType.EmailAddress)]
    [Required, RegularExpression(UserCreateViewModel.EmailRegex, ErrorMessage = UserCreateViewModel.EmailRegexError)]
    [Display(Name = "Email", Description = "")]
    public string Email { get; init; } = null!;
}
