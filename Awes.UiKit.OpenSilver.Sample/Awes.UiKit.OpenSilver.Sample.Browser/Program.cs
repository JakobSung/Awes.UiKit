using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Threading.Tasks;

namespace Awes.UiKit.OpenSilver.Sample.Browser
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddAwesUiKitService();

            var host = builder.Build();
            AwesUiKit.UseAwesUiKit(host.Services);
            await host.RunAsync();
        }
    }
}
