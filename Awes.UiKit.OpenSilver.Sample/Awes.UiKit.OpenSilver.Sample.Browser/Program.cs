using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Awes.UiKit.OpenSilver;

namespace Awes.UiKit.OpenSilver.Sample.Browser
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            // Add Awes.UiKit
            builder.Services.AddAwesUiKit();

            var host = builder.Build();
            await host.RunAsync();
        }
    }
}
