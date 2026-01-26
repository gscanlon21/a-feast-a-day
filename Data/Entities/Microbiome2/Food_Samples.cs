using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Microbiome;

class Food_Samples
{
    [Key, Required]
    public double SampleId { get; set; }

    public string? FoodId { get; set; }

    public string? Description { get; set; }

    public string? L1 { get; set; }

    public string? L4 { get; set; }

    public string? L6 { get; set; }

    public string? Nature { get; set; }

    public string? Process { get; set; }

    public string? Spoilage { get; set; }
}
