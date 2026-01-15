using Awes.UiKit;
using Awes.UiKit.OpenSilver.Builder;
using Awes.UiKit.OpenSilver.Sample;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System;
using System.Threading.Tasks;

namespace Awes.UiKit.OpenSilver.Sample.Browser
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = OpenSilverWasmHostBuilder.CreateHost<App>(args);
            await host.RunAsync();
        }
    }
}
