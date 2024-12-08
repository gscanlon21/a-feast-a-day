using Core.Dtos.User;
using Core.Models.Options;
using Microsoft.Extensions.Options;

namespace Lib;

public class DisplayHelper
{
    private readonly IOptions<SiteSettings> _siteSettings;

    public DisplayHelper(IOptions<SiteSettings> siteSettings)
    {
        _siteSettings = siteSettings;
    }

    public string NewsletterLink(UserNewsletterDto? user, DateOnly today)
    {
        if (user == null)
        {
            return string.Empty;
        }

        return $"{_siteSettings.Value.WebLink.TrimEnd('/')}/n/{Uri.EscapeDataString(user.Email)}/{today:O}?token={Uri.EscapeDataString(user.Token)}";
    }

    public string RecipeLink(UserNewsletterDto? user, string toPath)
    {
        if (user == null)
        {
            return string.Empty;
        }

        return $"{_siteSettings.Value.WebLink.TrimEnd('/')}/r/{Uri.EscapeDataString(user.Email)}/{toPath.Trim('/')}?token={Uri.EscapeDataString(user.Token)}";
    }

    public string IngredientLink(UserNewsletterDto? user, string toPath)
    {
        if (user == null)
        {
            return string.Empty;
        }

        return $"{_siteSettings.Value.WebLink.TrimEnd('/')}/i/{Uri.EscapeDataString(user.Email)}/{toPath.Trim('/')}?token={Uri.EscapeDataString(user.Token)}";
    }

    public string UserLink(UserNewsletterDto? user, string toPath)
    {
        if (user == null)
        {
            return string.Empty;
        }

        return $"{_siteSettings.Value.WebLink.TrimEnd('/')}/u/{Uri.EscapeDataString(user.Email)}/{toPath.Trim('/')}?token={Uri.EscapeDataString(user.Token)}";
    }

    public string UserActiveLink(UserNewsletterDto? user)
    {
        if (user == null)
        {
            return string.Empty;
        }

        //toPath = $"u/{Uri.EscapeDataString(_User.Email)}/{toPath.Trim('/')}?token={Uri.EscapeDataString(_User.Token)}";
        return $"{_siteSettings.Value.WebLink.TrimEnd('/')}/u/{Uri.EscapeDataString(user.Email)}/r?token={Uri.EscapeDataString(user.Token)}"; // &to={Uri.EscapeDataString(toPath)}
    }
}