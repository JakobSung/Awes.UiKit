using Awes.UiKit.OpenSilver;
using Awes.UiKit.OpenSilver.Sample.View;
using Awes.UiKit.OpenSilver.Sample.ViewModel;
using Awes.UiKit.OpenSilver.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;

namespace Awes.UiKit.OpenSilver.Sample
{
    public sealed partial class App : Application
    {
        public static IServiceProvider ServiceProvider => AwesUiKit.GetServiceProvider();

        public App()
        {
            this.InitializeComponent();

            var mainPage = new MainPage();
            Window.Current.Content = mainPage;
        }
    }
}
