
namespace Data.Query.Options;

public class DurationOptions : IOptions
{
    public DurationOptions() { }

    public int? MaxPrepTimeMinutes { get; set; }
    public int? MaxCookTimeMinutes { get; set; }
    public int? MaxTotalTimeMinutes { get; set; }
}
