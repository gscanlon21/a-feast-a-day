
namespace Terminal.Code.Helpers;

internal static class MeasureMap
{
    public static Dictionary<string, string> Map = new(StringComparer.OrdinalIgnoreCase)
    {
        [""] = "None",
        ["IU"] = "IU",
        ["International Unit"] = "IU",
        ["PH"] = "PH",
        ["G"] = "Grams",
        ["Gram"] = "Grams",
        ["kJ"] = "KiloJoule",
        ["kilojoule"] = "KiloJoule",
        ["KCAL"] = "KCalorie",
        ["kilocalorie"] = "KCalorie",
        ["UG"] = "Micrograms",
        ["�G"] = "Micrograms",
        ["Microgram"] = "Micrograms",
        ["MG"] = "Milligrams",
        ["Milligram"] = "Milligrams",
        ["MCG_RE"] = "MCG_RE",
        ["MG_GAE"] = "MG_GAE",
        ["MG_ATE"] = "MG_ATE",
        ["UMOL_TE"] = "UMOL_TE",
        ["SP_GR"] = "SpecificGravity",
        ["NE"] = "MG_NE",
        ["Niacin Equivalents"] = "MG_NE",
    };
}
