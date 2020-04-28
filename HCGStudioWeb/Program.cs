using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Blazor.FileReader;
using BlazorFileSaver;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using BlazorPrettyCode;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace HCGStudioWeb
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            //Configure services
            builder.Services
                .AddBlazorise(options =>
                {
                    options.ChangeTextOnKeyPress = true;
                })
                .AddFileReaderService(options => options.UseWasmSharedBuffer = true)
                .AddBaseAddressHttpClient()
                .AddBlazorPrettyCode()
                .AddBlazorFileSaver()
                .AddBootstrapProviders()
                .AddFontAwesomeIcons()
                .AddBaseAddressHttpClient();

            //build host
            var host = builder.Build();
            host.Services
                .UseBootstrapProviders()
                .UseFontAwesomeIcons();
            await host.RunAsync();
        }
    }
}
