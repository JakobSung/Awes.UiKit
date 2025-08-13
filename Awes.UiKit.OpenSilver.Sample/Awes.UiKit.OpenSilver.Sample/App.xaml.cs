using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Awes.UiKit.OpenSilver;
using Awes.UiKit.OpenSilver.Service;

namespace Awes.UiKit.OpenSilver.Sample
{
    public sealed partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public App()
        {
            this.InitializeComponent();

            try
            {
                var services = new ServiceCollection();
                services.AddSingleton<ILayoutManagerService, LayoutManagerService>();
                ServiceProvider = services.BuildServiceProvider();

                AwesUiKit.UseAwesUiKit(ServiceProvider);

            }
            catch (Exception ex)
            {

                throw;
            }
            

            var mainPage = new MainPage();
            Window.Current.Content = mainPage;


        }
    }
}
