using Awes.UiKit;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Controls;
#if NET10_0_OR_GREATER
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
#endif


namespace Awes.UiKit.OpenSilver.Builder
{
#if NET10_0_OR_GREATER
    /// <summary>
    /// OpenSilver WebAssembly 호스트 빌더
    /// </summary>
    public static class OpenSilverWasmHostBuilder
    {
        /// <summary>
        /// OpenSilver 호스트를 생성합니다
        /// </summary>
        public static WebAssemblyHost CreateHost<TApp>(string[] args) where TApp : ComponentBase
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<TApp>("#app");
            AwesUiKit.SetServices(builder.Services);
            var host = builder.Build();
            AwesUiKit.RegisterServiceProvider(host.Services, builder.Services);
            return host;            
        }
    }
#endif
}
