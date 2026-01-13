using Awes.UiKit;
using Awes.UiKit.Service;
using Awes.UiKit.OpenSilver.Sample.View;
using Awes.UiKit.OpenSilver.Sample.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Awes.UiKit.OpenSilver.Sample
{
    public partial class MainPage : Page
    {
        private bool _menuInitialized = false;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (_menuInitialized) return;
            _menuInitialized = true;
            InitMenu();
        }

        public void InitMenu()
        {
            try
            {
                ILayoutManagerService? layoutService = App.ServiceProvider.GetService(typeof(ILayoutManagerService)) as ILayoutManagerService;
                
                if (layoutService == null)
                {
                    MessageBox.Show("ILayoutManagerService not found in DI container");
                    return;
                }

                layoutService.AddMenu("DashBoard", typeof(DashBoardView), typeof(TestViewModel));
                layoutService.AddMenu("Test", typeof(TestContentView), typeof(TestViewModel));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing menu: {ex.Message}\n\n{ex.StackTrace}");
            }
        }
    }
}
