using Awes.UiKit.OpenSilver.Sample.View;
using Awes.UiKit.OpenSilver.Sample.ViewModel;
using Awes.UiKit.OpenSilver.Service;
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
        public MainPage()
        {
            this.InitializeComponent();
            InitMenu();
        }

        public void InitMenu()
        {
            try
            {
                ILayoutManagerService layoutService = App.ServiceProvider.GetService(typeof(ILayoutManagerService)) as ILayoutManagerService;
                

                layoutService.AddMenu("DashBoard", typeof(DashBoardView), typeof(TestViewModel));
                layoutService.AddMenu("Test", typeof(TestContentView), typeof(TestViewModel));

            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
    }
}
