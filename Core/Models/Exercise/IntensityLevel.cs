﻿using System.ComponentModel.DataAnnotations;

namespace Core.Models.Exercise;

/// <summary>
/// Endurance/Hypertrophy/Strength/Stabilization/Recovery/Warmup/Cooldown
/// </summary>
public enum Intensity
{
    /// <summary>
    /// For Isotonic/Isokinetic exercises, 1 x 15-20 rep range.
    /// For Isometric/Plyometric exercises, ~5x12-24s.
    /// </summary>
    [Display(Name = "Endurance")]
    Endurance = 0,

    /// <summary>
    /// For Isotonic/Isokinetic exercises, 2 x 12-15 rep range.
    /// For Isometric/Plyometric exercises, ~4x15-30s.
    /// </summary>
    [Display(Name = "Light", Description = "The target range for muscle failure will consist of few sets of many reps—ideal for lifting lighter weights and building muscular endurance.")]
    Light = 1,

    /// <summary>
    /// For Isotonic/Isokinetic exercises, 3 x 8-12 rep range.
    /// For Isometric/Plyometric exercises, ~3x20-40s.
    /// </summary>
    [Display(Name = "Medium", Description = "The target range for muscle failure will consist of a medial number of sets and reps—ideal for lifting medium weights and building muscle mass.")]
    Medium = 2,

    /// <summary>
    /// For Isotonic/Isokinetic exercises, 4 x 6-8 rep range.
    /// For Isometric/Plyometric exercises, ~2x30-60s.
    /// </summary>
    [Display(Name = "Heavy", Description = "The target range for muscle failure will consist of many sets of few reps—ideal for lifting heavy weights and building muscular strength.")]
    Heavy = 3,
}
