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
                layoutService.CallTest("Call from Sample1");
                layoutService.CallTest("Call from Sample2");
                layoutService.CallTest("Call from Sample3");
                layoutService.CallTest("Call from Sample4");
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
    }
}
