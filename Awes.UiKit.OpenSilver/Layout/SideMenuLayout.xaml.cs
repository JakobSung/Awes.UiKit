using Awes.UiKit.OpenSilver.Message;
using Awes.UiKit.OpenSilver.Service;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;

namespace Awes.UiKit.OpenSilver.Layout
{
    public partial class SideMenuLayout : UserControl
    {
        public SideMenuLayout()
        {
            this.InitializeComponent();
            this.Loaded += SideMenuLayout_Loaded;   
        }

        private void SideMenuLayout_Loaded(object sender, RoutedEventArgs e)
        {
            //ILayoutManagerService layout = ServiceExtension.ServiceProvider.GetService(typeof(ILayoutManagerService)) as ILayoutManagerService;
            //tbx.Text = layout.Test;

            ILayoutManagerService serivce = AwesUiKit.ServiceProvider.GetService<ILayoutManagerService>();
            tbx.Text = serivce.Test;

            WeakReferenceMessenger.Default.Register<SideMenuLayoutMessage>(this, (r, m) =>
            {
                tbx.Text = new StringBuilder(tbx.Text).AppendLine(m.Message).ToString();
            });
        }
    }
}
