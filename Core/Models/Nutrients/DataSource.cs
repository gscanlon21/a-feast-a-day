using System.ComponentModel.DataAnnotations;

namespace Core.Models.Nutrients;

public enum DataSource
{
    [Display(Name = "U.S. Department of Agriculture", ShortName = "USDA")]
    USDA = 1,

    [Display(Name = "Health Canada", ShortName = "Health Canada")]
    Canada = 2,
}
