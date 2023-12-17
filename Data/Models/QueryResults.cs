using Core.Models.Newsletter;
using Data.Entities.Exercise;
using Data.Entities.User;
using System.Diagnostics;

namespace Data.Models;

[DebuggerDisplay("{Exercise}: {Variation}")]
public record QueryResults(
    Section Section,
    Exercise Exercise,
    UserExercise? UserExercise
);