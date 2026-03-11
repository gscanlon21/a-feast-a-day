// See https://aka.ms/new-console-template for more information
using Data;
using Data.Repos;
using Microsoft.EntityFrameworkCore;
using Terminal.Options;
using Terminal.Programs;
using Terminal.Programs.HealthCanada;
using Terminal.Programs.USDA;

using var host = Host.CreateDefaultBuilder()
    .ConfigureAppConfiguration((context, config) =>
    {
        config.SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
    })
    .ConfigureServices((context, services) =>
    {
        services.AddDbContext<CoreContext>(options => options.UseNpgsql(context.Configuration.GetConnectionString("CoreContext") ?? throw new InvalidOperationException("Connection string 'CoreContext' not found."), options =>
        {
            options.UseQuerySplittingBehavior(QuerySplittingBehavior.SingleQuery);
        }));

        services.AddHttpClient();
        services.AddTransient<Runner>();
        services.AddTransient<UserRepo>();
        services.AddTransient<NutrientRepo>();
        services.AddTransient<RegenerateNutrients>();
        services.AddTransient<LoadUSDANutrientData>();
        services.AddTransient<DownloadUSDADatasets>();
        services.AddTransient<RegenerateUSDANutrients>();
        services.AddTransient<LoadHealthCanadaNutrientData>();
        services.AddTransient<DownloadHealthCanadaDatasets>();
        services.AddTransient<RegenerateHealthCanadaNutrients>();

        services.Configure<USDASettings>(context.Configuration.GetSection("USDA"));
        services.Configure<HealthCanadaSettings>(context.Configuration.GetSection("HealthCanada"));
    }).Build();

await host.Services.GetRequiredService<Runner>().Run();
