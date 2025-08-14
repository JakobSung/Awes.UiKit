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
        public App()
        {
            this.InitializeComponent();



            var mainPage = new MainPage();
            Window.Current.Content = mainPage;
        }
    }
}
