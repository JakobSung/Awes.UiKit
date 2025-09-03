#if NET9_0
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Awes.UiKit.OpenSilver.Service;

namespace Awes.UiKit.OpenSilver
{
    public static class UseAwesUiKitExtensions
    {
        /// <summary>
        /// Registers Awes.UiKit services and builds the host while initializing the global service provider.
        /// This unifies the responsibilities of AddAwesUiKitService and AwesUiKit.UseAwesUiKit(host.Services).
        /// </summary>
        /// <param name="builder">The WebAssembly host builder.</param>
        /// <returns>The built WebAssemblyHost instance.</returns>
        public static WebAssemblyHostBuilder RegistRequireService(this WebAssemblyHostBuilder builder)
        {
            // Register required services
            builder.Services.AddSingleton<ILayoutManagerService, LayoutManagerService>();

            return builder;
            
        }
    }
}
#endif
