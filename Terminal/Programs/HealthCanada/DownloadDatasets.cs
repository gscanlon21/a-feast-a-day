using System.IO.Compression;

namespace Terminal.Programs.HealthCanada;

/// <summary>
/// Downloads the entire dataset from Health Canada.
/// </summary>
internal class DownloadHealthCanadaDatasets
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public DownloadHealthCanadaDatasets(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _configuration = configuration;
        _httpClient = httpClientFactory.CreateClient();
        _httpClient.Timeout = Timeout.InfiniteTimeSpan;
    }

    public async Task<Response> Execute()
    {
        var downloadPath = _configuration.GetValue<string>("DownloadPath")?.NullIfWhiteSpace() ?? AppContext.BaseDirectory;

        Console.WriteLine("Go here: https://www.canada.ca/en/health-canada/services/food-nutrition/healthy-eating/nutrient-data/canadian-nutrient-file-about-us.html");
        Console.WriteLine("What is the download file link?");
        var url = Console.ReadLine();

        using var response = (await _httpClient.GetAsync(url)).EnsureSuccessStatusCode();

        using var memoryStream = new MemoryStream();
        await response.Content.CopyToAsync(memoryStream);

        Console.WriteLine($"Writing to directory: {downloadPath}");
        await ZipFile.ExtractToDirectoryAsync(memoryStream, downloadPath);

        return Response.Success();
    }
}
