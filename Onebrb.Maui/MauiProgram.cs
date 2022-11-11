using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Onebrb.Maui.Data;
using Onebrb.Maui.MsalClient;
using System.Reflection;

namespace Onebrb.Maui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<WeatherForecastService>();

            var executingAssembly = Assembly.GetExecutingAssembly();

            using var stream = executingAssembly.GetManifestResourceStream("Onebrb.Maui.appsettings.json");

            var configuration = new ConfigurationBuilder()
                        .AddJsonStream(stream)
                        .Build();

            builder.Services.AddTransient<MainPage>();
            builder.Services.AddSingleton<WeatherForecastService>();
            builder.Services.AddSingleton<IPCAWrapper, PCAWrapper>();
            builder.Configuration.AddConfiguration(configuration);

            return builder.Build();
        }
    }
}