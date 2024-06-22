using Core.Models.Recipe;

namespace Data.Query.Options;

public class EquipmentOptions : IOptions
{
    public EquipmentOptions() { }

    public EquipmentOptions(Equipment? equipment)
    {
        Equipment = equipment;
    }

    public Equipment? Equipment { get; set; }
}
