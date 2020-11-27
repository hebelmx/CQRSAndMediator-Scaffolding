using Client.Api;
using Fluxor;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Net.Mime;
using System.Reflection;
using System.Threading.Tasks;
using Client.Projects.Services;
using Client.Projects.State;

namespace BlazorApp1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            // Add Fluxor
            builder.Services.AddFluxor(options =>
            {
                options.ScanAssemblies(Assembly.GetExecutingAssembly());
                options.ScanAssemblies(typeof(ProjectsState).Assembly);
                options.UseReduxDevTools();
            });

            // Add custom application services
            builder.Services.AddScoped<ProjectsService>();

            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri("https://jsonplaceholder.typicode.com") });

            builder.Services.AddHttpClient<ProjectApiService>(client =>
            {
                client.DefaultRequestHeaders.Add("Content-Control", $"{MediaTypeNames.Application.Json}; charset=utf-8");
                client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
            });

            //builder.Services.AddOidcAuthentication(options =>
            //{
            //    // Configure your authentication provider options here. For more information, see https://aka.ms/blazor-standalone-auth
            //    builder.Configuration.Bind("Local", options.ProviderOptions);
            //});

            await builder.Build().RunAsync();
        }
    }
}