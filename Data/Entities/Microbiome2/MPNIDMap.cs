using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Microbiome;

public class MPNIDMap
{
    [Key, Required]
    public int OldNId { get; set; }

    [Required]
    public int MpNID { get; set; }
}
