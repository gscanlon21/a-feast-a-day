using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Microbiome.Thorne;

public class Thorne
{
    [Key, Required]
    public int ThorneId { get; set; }

    public string Domain { get; set; } = null!;

    public string Kingdom { get; set; } = null!;

    public string Phylum { get; set; } = null!;

    public string Class { get; set; } = null!;

    public string Order { get; set; } = null!;

    public string Family { get; set; } = null!;

    public string Genus { get; set; } = null!;

    public string Species { get; set; } = null!;

    public string Strain { get; set; } = null!;

    public int? Taxon { get; set; }
}
