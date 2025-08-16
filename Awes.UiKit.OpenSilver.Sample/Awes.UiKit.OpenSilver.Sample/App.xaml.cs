using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Awes.UiKit.OpenSilver;
using Awes.UiKit.OpenSilver.Service;
using Awes.UiKit.OpenSilver.Sample.View;
using Awes.UiKit.OpenSilver.Sample.ViewModel;

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

                services.AddScoped<DashBoardView>();
                services.AddScoped<TestContentView>();
                services.AddScoped<TestViewModel>();

                ServiceProvider = services.BuildServiceProvider();

                AwesUiKit.UseAwesUiKit(ServiceProvider);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            var mainPage = new MainPage();
            Window.Current.Content = mainPage;
        }
    }
}
