using Terminal.Programs.HealthCanada;
using Terminal.Programs.USDA;

namespace Terminal.Programs;

internal class Runner
{
    private readonly DownloadUSDADatasets _downloadUSDADatasets;
    private readonly LoadUSDANutrientData _loadUSDANutrientData;
    private readonly RegenerateUSDANutrients _regenerateUSDANutrients;
    private readonly DownloadHealthCanadaDatasets _downloadHealthCanadaDatasets;
    private readonly LoadHealthCanadaNutrientData _loadHealthCanadaNutrientData;
    private readonly RegenerateHealthCanadaNutrients _regenerateHealthCanadaNutrients;
    private readonly RegenerateNutrients _regenerateNutrients;

    public Runner(DownloadUSDADatasets downloadUSDADatasets,
        LoadUSDANutrientData loadUSDANutrientData,
        RegenerateUSDANutrients regenerateUSDANutrients,
        DownloadHealthCanadaDatasets downloadHealthCanadaDatasets,
        LoadHealthCanadaNutrientData loadHealthCanadaNutrientData,
        RegenerateHealthCanadaNutrients regenerateHealthCanadaNutrients,
        RegenerateNutrients regenerateNutrients)
    {
        _downloadUSDADatasets = downloadUSDADatasets;
        _loadUSDANutrientData = loadUSDANutrientData;
        _regenerateUSDANutrients = regenerateUSDANutrients;
        _downloadHealthCanadaDatasets = downloadHealthCanadaDatasets;
        _loadHealthCanadaNutrientData = loadHealthCanadaNutrientData;
        _regenerateHealthCanadaNutrients = regenerateHealthCanadaNutrients;
        _regenerateNutrients = regenerateNutrients;
    }

    public async Task Run()
    {
        ConsoleKeyInfo actionKeyPressed;
        do
        {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1: Download datasets from FDA's FoodData Central");
            Console.WriteLine("2: Download datasets from Health Canada");
            Console.WriteLine("3: Load USDA nutrient data from a CSV file");
            Console.WriteLine("4: Load Health Canada nutrient data from a CSV file");
            Console.WriteLine("5: Regenerate USDA Nutrients");
            Console.WriteLine("6: Regenerate Health Canada Nutrients");
            Console.WriteLine("7: Regenerate Nutrients");
            Console.WriteLine("0: Exit");
            actionKeyPressed = Console.ReadKey();

            Console.WriteLine();
            Console.WriteLine();

            try
            {
                var response = actionKeyPressed.KeyChar switch
                {
                    '1' => await _downloadUSDADatasets.Execute(),
                    '2' => await _downloadHealthCanadaDatasets.Execute(),
                    '3' => await _loadUSDANutrientData.Execute(),
                    '4' => await _loadHealthCanadaNutrientData.Execute(),
                    '5' => await _regenerateUSDANutrients.Execute(),
                    '6' => await _regenerateHealthCanadaNutrients.Execute(),
                    '7' => await _regenerateNutrients.Execute(),
                    _ => Response.Success(),
                };

                if (response.Status == ResponseStatus.Failure)
                {
                    Console.WriteLine(response.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();
            Console.WriteLine();
        }
        while (actionKeyPressed.KeyChar != '0');
    }
}
