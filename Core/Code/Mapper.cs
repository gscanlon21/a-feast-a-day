using System.Text.Json;
using System.Text.Json.Serialization;

namespace Web.Code;

public static class Mapper
{
    private static readonly JsonSerializerOptions Options = new()
    {
        ReferenceHandler = ReferenceHandler.Preserve
    };

    public static T? AsType<T, F>(this F from) where T : new()
    {
        return JsonSerializer.Deserialize<T>(JsonSerializer.Serialize(from, Options), Options);
    }
}
