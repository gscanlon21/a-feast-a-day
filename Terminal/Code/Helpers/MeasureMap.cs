
namespace Terminal.Code.Helpers;

internal static class MeasureMap
{
    public static Dictionary<string, string> Map = new(StringComparer.OrdinalIgnoreCase)
    {
        [""] = "None",
        ["IU"] = "IU",
        ["PH"] = "PH",
        ["G"] = "Grams",
        ["kJ"] = "KiloJoule",
        ["KCAL"] = "KCalorie",
        ["UG"] = "Micrograms",
        ["MG"] = "Milligrams",
        ["MCG_RE"] = "MCG_RE",
        ["MG_GAE"] = "MG_GAE",
        ["MG_ATE"] = "MG_ATE",
        ["UMOL_TE"] = "UMOL_TE",
        ["SP_GR"] = "SpecificGravity"
    };
}
