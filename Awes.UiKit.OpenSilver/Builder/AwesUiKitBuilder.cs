#if NET9_0
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Awes.UiKit.OpenSilver.Builder
{
    public class AwesUiKitBuilder
    {
        private WebAssemblyHostBuilder _builder;

        public AwesUiKitBuilder(WebAssemblyHostBuilder builder)
        {
            this._builder = builder;
            _builder.RegistRequireService();
        }

        public void ConfigureServices(System.Action<Microsoft.Extensions.DependencyInjection.IServiceCollection> action)
        {
            action.Invoke(_builder.Services);
        }

        public WebAssemblyHost Build()
        {
            var host = _builder.Build();
            AwesUiKit.RegistServiceProvdier(host.Services);
            return host;
        }
    }
}
#endif