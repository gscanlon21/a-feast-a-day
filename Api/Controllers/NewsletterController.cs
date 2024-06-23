using Core.Code.Exceptions;
using Core.Consts;
using Core.Models;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public partial class NewsletterController(NewsletterRepo newsletterRepo) : ControllerBase
{
    [HttpGet("Footnotes")]
    public async Task<IActionResult> GetFootnotes(string? email = null, string? token = null, int count = 1)
    {
        var footnotes = await newsletterRepo.GetFootnotes(email, token, count);
        return StatusCode(StatusCodes.Status200OK, footnotes);
    }

    [HttpGet("Footnotes/Custom")]
    public async Task<IActionResult> GetUserFootnotes(string email = UserConsts.DemoUser, string token = UserConsts.DemoToken, int count = 1)
    {
        var footnotes = await newsletterRepo.GetUserFootnotes(email, token, count);
        return StatusCode(StatusCodes.Status200OK, footnotes);
    }

    /// <summary>
    /// Root route for building out the the workout routine newsletter.
    /// </summary>
    [HttpGet("Newsletter")]
    public async Task<IActionResult> GetNewsletter(string email = UserConsts.DemoUser, string token = UserConsts.DemoToken, DateOnly? date = null, Client client = Client.Email)
    {
        try
        {
            var newsletter = await newsletterRepo.Newsletter(email, token, date);
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
}
