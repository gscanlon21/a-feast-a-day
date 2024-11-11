﻿using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Web.Views.Shared.Components.PastFeasts;

namespace Web.Components.User;

public class PastFeastsViewComponent : ViewComponent
{
    private readonly UserRepo _userRepo;

    public PastFeastsViewComponent(UserRepo userRepo)
    {
        _userRepo = userRepo;
    }

    /// <summary>
    /// For routing.
    /// </summary>
    public const string Name = "PastFeasts";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user)
    {
        var count = int.TryParse(Request.Query["count"], out int countTmp) ? countTmp : (int?)null;
        var pastFeasts = await _userRepo.GetPastFeasts(user, count);
        if (!pastFeasts.Any())
        {
            return Content("");
        }

        return View("PastFeasts", new PastFeastsViewModel()
        {
            User = user,
            PastFeasts = pastFeasts,
            Token = await _userRepo.AddUserToken(user, durationDays: 1),
        });
    }
}
