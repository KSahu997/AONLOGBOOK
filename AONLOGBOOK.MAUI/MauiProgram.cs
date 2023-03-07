using AONLOGBOOK.MAUI.Services;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Components.WebView.Maui;

namespace AONLOGBOOK.MAUI
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
            builder.Services
               .AddBlazorise(options =>
               {
                   options.Immediate = false;
               })
               .AddBootstrapProviders()
               .AddFontAwesomeIcons();

            builder.Services.AddMauiBlazorWebView();
            //#if DEBUG
		            builder.Services.AddBlazorWebViewDeveloperTools();
            //#endif
            builder.Services.AddScoped<IHttpService, HttpServices>();

            builder.Services.AddSingleton(x =>
            {
                var httpClientHandler = new HttpClientHandler();
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, certificate, chain, sslPolicyErrors) => true;
                HttpClient client = new HttpClient(httpClientHandler,false);

                //var ApiUrl = new Uri("https://aonapps.in:7070/api/");
                //var ApiUrl = new Uri("http://192.168.0.135:6070/api/");
                var ApiUrl = new Uri("https://localhost:7222/api/");
                client.BaseAddress = ApiUrl;
                //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("admin", "@admin123");
                return client;
            });
            return builder.Build();
        }
    }
}