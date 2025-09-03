#if NET9_0
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components;

namespace Awes.UiKit.OpenSilver.Builder
{
    public static class AwesUiKitWasmHostBuilder
    {
        public static AwesUiKitBuilder CreateHost<TApp>(string[] args) where TApp : ComponentBase
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<TApp>("#app");
            return new AwesUiKitBuilder(builder);
        }
    }
}

#endif
