using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Awes.UiKit.Wpf.Sample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            WpfHost host = new WPFHostBuilder(this)
                                    .ConfigureStartWindow<MainWindow>()
                                    .ConfigureServices(services =>
                                    {
                                        //todo: add services here
                                    })
                                    .Build();

            Task.Run(async () => await host.RunAsync());
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
          
        }


        
        


    }
}
