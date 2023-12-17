﻿using Core.Models.User;
using Data.Entities.Newsletter;
using Data.Models.Newsletter;

namespace Web.ViewModels.User.Components;


public class NextWorkoutViewModel
{
    public Days Today { get; init; }

    /// <summary>
    /// Negative if the next workout is in the process of sending.
    /// Otherwise the duration until the next workout starts sending.
    /// </summary>
    public TimeSpan? TimeUntilNextSend { get; init; }

    public bool NextWorkoutSendsToday { get; init; }

    public WorkoutRotation MobilityRotation { get; init; } = null!;

    public Data.Entities.User.User User { get; init; } = null!;

    public string Token { get; init; } = null!;
}
