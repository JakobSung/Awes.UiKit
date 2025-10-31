using System.Configuration;
using System.Data;
using System.Windows;

namespace Awes.UiKit.Wpf.Sample
{
    public class WPFHostBuilder
    {
        //todo : awes.uikit.wpf로 옮기기, WPF전용 hostbuilder구현, awes.uikit에 공통기능 구현 고민(예: 상속) awes.uikit hostbuilder와 통합방안 고민


        App _app;
        public WPFHostBuilder(App app)
        {
            _app = app;
            
            //app.StartupUri = null;

            _app.Startup += App_Startup;    
            _app.Exit += App_Exit;
        }

        private void App_Exit(object sender, ExitEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void App_Startup(object sender, StartupEventArgs e)
        {
            //throw new NotImplementedException();
        }

        internal object ConfigureStartWindow<T>()
        {
            throw new NotImplementedException();
        }

        //public object ConfigureServices(System.Action<Microsoft.Extensions.DependencyInjection.IServiceCollection> action)
        //{
        //    action.Invoke(_builder.Services);
        //}

        //public IHost Build()
        //{
        //    var host = _builder.Build();
        //    AwesUiKit.RegistServiceProvdier(host.Services);
        //    return host;
        //}
    }



    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //private WPFHost _host;

        public App()
        {
            //todo : wpfhost 구현방안 고민, 한번의 설정으로 DI구현과 스타트윈도우 설정을 할수있도록

            var host = new WPFHostBuilder(this);
            //WPFHost host = new WPFHostBuilder(this)
            //                        .ConfigureStartWindow<MainWindow>()
            //                        .ConfigureServices(services =>
            //                        {
            //                            services.AddSingleton<ITextService, TextService>();
            //                        })
            //                        .Build();




        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            
        }
    }
}
