using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Microbiome;

internal class MPNIDMap
{
    [Key, Required]
    public int OldNId { get; set; }

    [Required]
    public int MpNID { get; set; }
}
