using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

internal class Condition2Condition
{
    [Key, Column(Order = 0)]
    [Required]
    public int CondId1 { get; set; }

    [Key, Column(Order = 1)]
    [Required]
    public int CondId2 { get; set; }

    [Required]
    public int From1 { get; set; }

    [Required]
    public int From2 { get; set; }

    public int? Common { get; set; }

    // AS (((100.0)*[Common])/CONVERT([float],[From1])),
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public double PC1 { get; private set; }

    // AS (((100.0)*[Common])/CONVERT([float],[From2])),
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public double PC2 { get; private set; }
}

