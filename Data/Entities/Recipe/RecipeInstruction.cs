using Core.Models.Recipe;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Data.Entities.Recipe;

/// <summary>
/// A recipe's instructions.
/// </summary>
[Table("recipe_instruction")]
[DebuggerDisplay("{Name,nq}")]
public class RecipeInstruction
{
    // Not private so json can bind to it.
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    [Required]
    public int Order { get; init; }

    [Required]
    [Display(Name = "Equipment", Description = "Equipment for each instruction is OR-ed.")]
    public Equipment Equipment { get; set; }

    [Required]
    public string Name { get; init; } = null!;

    [NotMapped]
    public bool Hide { get; init; }


    [NotMapped]
    public Equipment[]? EquipmentBinder
    {
        get => Enum.GetValues<Equipment>().Where(e => Equipment.HasFlag(e)).ToArray();
        set => Equipment = value?.Aggregate(Equipment.None, (a, e) => a | e) ?? Equipment.None;
    }


    #region Navigation Properties

    [JsonIgnore, InverseProperty(nameof(Entities.Recipe.Recipe.Instructions))]
    public virtual Recipe Recipe { get; private init; } = null!;

    #endregion


    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is RecipeInstruction other
        && other.Id == Id;
}
