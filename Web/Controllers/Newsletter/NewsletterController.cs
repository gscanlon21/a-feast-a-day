using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace Web.Controllers.Newsletter;

[Route($"n/{UserRoute}", Order = 1)]
[Route($"newsletter/{UserRoute}", Order = 2)]
public class NewsletterController(NewsletterRepo newsletterService) : ViewController()
{
    /// <summary>
    /// The name of the controller for routing purposes.
    /// </summary>
    public const string Name = "Newsletter";

    /// <summary>
    /// Root route for building out the meal plan newsletter.
    /// </summary>
    [HttpGet]
    [Route($"{{date}}", Order = 1)]
    [Route("demo", Order = 2)]
    [Route("", Order = 3)]
    public async Task<IActionResult> Newsletter(string email = UserConsts.DemoUser, string token = UserConsts.DemoToken, DateOnly? date = null, Client client = Client.Web, bool hideFooter = false)
    {
        //Response.GetTypedHeaders().LastModified = newsletter?.UserWorkout.DateTime;
        Response.GetTypedHeaders().CacheControl = new CacheControlHeaderValue
        {
            // Breaks the contact-us link: https://developers.cloudflare.com/support/more-dashboard-apps/cloudflare-scrape-shield/what-is-email-address-obfuscation/
            NoTransform = true,
            // NoCache would be better for when an old newsletter exists. Just wanting the demo to always receive fresh content for now.
            NoStore = true,
        };

        var newsletter = await newsletterService.Newsletter(email, token, date);
        if (newsletter != null)
        {
            newsletter.Client = client;
            newsletter.HideFooter = hideFooter;
            return View(nameof(Newsletter), newsletter);
        }

        return NoContent();
    }
}
