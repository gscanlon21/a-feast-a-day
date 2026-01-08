using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace Web.Controllers.Newsletter;

[Route("demo", Order = 3)]
[Route($"n/{UserRoute}", Order = 1)]
[Route($"newsletter/{UserRoute}", Order = 2)]
public class NewsletterController : ViewController
{
    private readonly NewsletterRepo _newsletterRepo;

    public NewsletterController(NewsletterRepo newsletterRepo)
    {
        _newsletterRepo = newsletterRepo;
    }

    /// <summary>
    /// The name of the controller for routing purposes.
    /// </summary>
    public const string Name = "Newsletter";

    /// <summary>
    /// Root route for building out the meal plan newsletter.
    /// </summary>
    [HttpGet]
    [Route("", Order = 2)]
    [Route("{date:datetime}", Order = 1)]
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

        var newsletter = await _newsletterRepo.Newsletter(email, token, date);
        if (newsletter != null)
        {
            newsletter.Client = client;
            newsletter.HideFooter = hideFooter;
            return View(nameof(Newsletter), newsletter);
        }

        return NoContent();
    }

    /// <summary>
    /// Root route for building out the meal plan newsletter.
    /// </summary>
    [HttpGet]
    [Route("shoppinglist", Order = 2)]
    [Route("{date:datetime}/shoppinglist", Order = 1)]
    public async Task<IActionResult> ShoppingList(string email = UserConsts.DemoUser, string token = UserConsts.DemoToken, DateOnly? date = null, Client client = Client.Web, bool hideFooter = false)
    {
        //Response.GetTypedHeaders().LastModified = newsletter?.UserWorkout.DateTime;
        Response.GetTypedHeaders().CacheControl = new CacheControlHeaderValue
        {
            // Breaks the contact-us link: https://developers.cloudflare.com/support/more-dashboard-apps/cloudflare-scrape-shield/what-is-email-address-obfuscation/
            NoTransform = true,
            // NoCache would be better for when an old newsletter exists. Just wanting the demo to always receive fresh content for now.
            NoStore = true,
        };

        var newsletter = await _newsletterRepo.Newsletter(email, token, date);
        if (newsletter != null)
        {
            newsletter.Client = client;
            newsletter.HideFooter = hideFooter;
            return View(nameof(ShoppingList), newsletter.ShoppingList);
        }

        return NoContent();
    }
}
