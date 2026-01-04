using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Data.Entities.Genetics;

/// <summary>
/// A study's ingredients.
/// </summary>
[Table("study_ingredient")]
[DebuggerDisplay("StudyId: {StudyId}, IngredientId: {IngredientId}")]
public class StudyIngredient
{
    public virtual int StudyId { get; private init; }
    public virtual int IngredientId { get; private init; }


    [InverseProperty(nameof(Genetics.Study.StudyIngredients))]
    public virtual Study Study { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(Ingredients.Ingredient.StudyIngredients))]
    public virtual Ingredients.Ingredient Ingredient { get; private init; } = null!;
}
