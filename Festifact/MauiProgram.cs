using Microsoft.Extensions.Logging;
using Festifact.Data;
using Microsoft.AspNetCore.Components;
using Festifact.Services;

namespace Festifact;

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

        // setup the httpclient for dependency injection
        var handler = new HttpClientHandler();
        handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
        var httpClient = new HttpClient(handler);
        var baseUrl = "";
        if (DeviceInfo.Platform == DevicePlatform.Android)
        {
            baseUrl = "https://10.0.2.2:7228";
        }
        else
        {
            baseUrl = "https://localhost:7228";
        }
        httpClient.BaseAddress = new Uri(baseUrl);
        builder.Services.AddSingleton(httpClient);

        builder.Services.AddSingleton<OrganisatorService>();
        builder.Services.AddSingleton<FestivalService>();
        builder.Services.AddSingleton<ZaalsService>();
        builder.Services.AddSingleton<BezoekerService>();
        return builder.Build();
	}
}
