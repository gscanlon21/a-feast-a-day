﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Data.Entities.Genetics;

/// <summary>
/// Pre-requisite exercises for other exercises
/// </summary>
[Table("study_ingredient")]
[DebuggerDisplay("{Exercise} needs {PrerequisiteExercise}")]
public class StudyIngredient
{
    public virtual int StudyId { get; private init; }
    public virtual int IngredientId { get; private init; }


    [InverseProperty(nameof(Genetics.Study.StudyIngredients))]
    public virtual Study Study { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(Entities.Ingredient.Ingredient.StudyIngredients))]
    public virtual Ingredient.Ingredient Ingredient { get; private init; } = null!;
}
