using Awes.UiKit.OpenSilver.Builder;
using Awes.UiKit.OpenSilver.Sample.View;
using Awes.UiKit.OpenSilver.Sample.ViewModel;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.DataVisualization.Charting;

namespace Awes.UiKit.OpenSilver.Sample.Browser
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = AwesUiKitWasmHostBuilder.CreateHost<App>(args);

            builder.ConfigureServices(services =>
            {
                services.AddScoped<DashBoardView>();
                services.AddScoped<TestContentView>();
                services.AddScoped<TestViewModel>();
            });
            
            var host = builder.Build();

            await host.RunAsync();
        }
    }
}
