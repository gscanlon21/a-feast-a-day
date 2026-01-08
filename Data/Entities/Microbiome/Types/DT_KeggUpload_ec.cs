using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Microbiome.Types;

public class DT_KeggUpload_ec
{
    [Key]
    public string Entry { get; set; } = null!;
    public string? Name { get; set; }
    public string? SysName { get; set; }
    public string? Substrate { get; set; }
    public string? Product { get; set; }
}

