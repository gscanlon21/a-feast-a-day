﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;

[Table("special_conditions_tax")]
[DebuggerDisplay("{Name,nq}")]
public class SpecialConditionsTax
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    [Key, Column(Order = 0)]
    [Required]
    public int SymptomId { get; set; }

    [Key, Column(Order = 1)]
    [Required]
    public int Taxon { get; set; }

    public double? Q4High { get; set; }

    public int? Obs { get; set; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}

