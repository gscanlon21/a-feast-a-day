namespace Core.Dtos.Nutrients;

public class NutrientDto
{
    public int Id { get; init; }

    public int Order { get; set; }

    public string Key { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Notes { get; set; } = null;
}
