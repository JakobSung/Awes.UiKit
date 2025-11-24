using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Awes.UiKit.Wpf
{
    public class WPFHostBuilder
    {
        Application _app;

        public WPFHostBuilder(Application app)
        {
            _app = app;

            //app.StartupUri = null;

            _app.Startup += App_Startup;
            _app.Exit += App_Exit;
        }

        private void App_Exit(object sender, ExitEventArgs e)
        {
            
        }

        private void App_Startup(object sender, StartupEventArgs e)
        {
            
        }

        //public object ConfigureStartWindow<T>()
        //{
            
        //}

        public object ConfigureServices(System.Action<Microsoft.Extensions.DependencyInjection.IServiceCollection> action)
        {
            action.Invoke(_builder.Services);
        }

        //public IHost Build()
        //{
        //    var host = _builder.Build();
        //    AwesUiKit.RegistServiceProvdier(host.Services);
        //    return host;
        //}
    }

}
