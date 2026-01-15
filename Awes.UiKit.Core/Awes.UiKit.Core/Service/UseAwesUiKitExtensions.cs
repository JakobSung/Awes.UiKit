#if NET10_0
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
#endif
using Awes.UiKit.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Awes.UiKit
{
    public static class UseAwesUiKitExtensions
    {
        public static IServiceCollection AddAwesUiKitServices(this IServiceCollection services)
        {
            services.AddSingleton<ILayoutManagerService, LayoutManagerService>();
            return services;
        }

#if NET10_0
        public static WebAssemblyHostBuilder RegistRequireService(this WebAssemblyHostBuilder builder)
        {
            builder.Services.AddAwesUiKitServices();
            return builder;
        }
#endif
    }
}
