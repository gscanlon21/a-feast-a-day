using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Microbiome.Thorne;

public class Thorne
{
    public string Domain { get; set; }

    public string Kingdom { get; set; }

    public string Phylum { get; set; }

    public string Class { get; set; }

    public string Order { get; set; }

    public string Family { get; set; }

    public string Genus { get; set; }

    public string Species { get; set; }

    public string Strain { get; set; }

    [Key]
    [Required]
    public int ThorneId { get; set; }

    public int? Taxon { get; set; }
}
