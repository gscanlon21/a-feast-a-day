using Api.Jobs.Create;
using Core.Code.Exceptions;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Quartz;

namespace Api.Controllers;

[ApiController, Route("[controller]")]
public class NewsletterController : ControllerBase
{
    private readonly UserRepo _userRepo;
    private readonly NewsletterRepo _newsletterRepo;
    private readonly ISchedulerFactory _schedulerFactory;

    public NewsletterController(NewsletterRepo newsletterRepo, UserRepo userRepo, ISchedulerFactory schedulerFactory)
    {
        _userRepo = userRepo;
        _newsletterRepo = newsletterRepo;
        _schedulerFactory = schedulerFactory;
    }

    [HttpGet("Footnotes")]
    public async Task<IActionResult> GetFootnotes(string? email = null, string? token = null, int count = 1)
    {
        var footnotes = await _newsletterRepo.GetFootnotes(email, token, count);
        return StatusCode(StatusCodes.Status200OK, footnotes);
    }

    [HttpGet("Footnotes/Custom")]
    public async Task<IActionResult> GetUserFootnotes(string email = UserConsts.DemoUser, string token = UserConsts.DemoToken, int count = 1)
    {
        var footnotes = await _newsletterRepo.GetUserFootnotes(email, token, count);
        return StatusCode(StatusCodes.Status200OK, footnotes);
    }

    /// <summary>
    /// Root route for building out the weekly feast newsletter.
    /// </summary>
    [HttpGet("Newsletter")]
    public async Task<IActionResult> GetNewsletter(string email = UserConsts.DemoUser, string token = UserConsts.DemoToken, DateOnly? date = null, Client client = Client.Web)
    {
        try
        {
            var newsletter = await _newsletterRepo.Newsletter(email, token, date);
            if (newsletter != null)
            {
                newsletter.Client = client;
                return StatusCode(StatusCodes.Status200OK, newsletter);
            }

            return StatusCode(StatusCodes.Status204NoContent);
        }
        catch (UserException)
        {
            return StatusCode(StatusCodes.Status401Unauthorized);
        }
    }

    /// <summary>
    /// Get the user's past newsletters.
    /// </summary>
    [HttpGet("Newsletters")]
    public async Task<IActionResult> GetNewsletters(string email = UserConsts.DemoUser, string token = UserConsts.DemoToken)
    {
        var user = await _userRepo.GetUser(email, token);
        if (user == null)
        {
            return StatusCode(StatusCodes.Status204NoContent);
        }

        var feasts = await _userRepo.GetPastFeasts(user);
        return StatusCode(StatusCodes.Status200OK, feasts);
    }

    /// <summary>
    /// Root route for building out the weekly feast newsletter.
    /// </summary>
    [HttpGet("Backfill")]
    public async Task<IActionResult> Backfill(string email = UserConsts.DemoUser, string token = UserConsts.DemoToken)
    {
        try
        {
            var user = await _userRepo.GetUserStrict(email, token);
            await CreateBackfill.Trigger(await _schedulerFactory.GetScheduler(), user, token);

            return StatusCode(StatusCodes.Status204NoContent);
        }
        catch (UserException)
        {
            return StatusCode(StatusCodes.Status401Unauthorized);
        }
    }
}
