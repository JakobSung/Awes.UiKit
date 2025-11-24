using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Awes.UiKit.Wpf
{
    public class AwesWpfApp : Application
    {
        public AwesWpfApp()
        {
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
