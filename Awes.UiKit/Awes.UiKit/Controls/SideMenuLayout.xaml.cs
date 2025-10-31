using Awes.UiKit.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Extensions.DependencyInjection;

namespace Awes.UiKit.Controls
{
    /// <summary>
    /// SideMenuLayout.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SideMenuLayout : UserControl
    {
        public static readonly DependencyProperty MenuItemTemplateProperty = DependencyProperty.Register("MenuItemTemplate", typeof(DataTemplate), typeof(SideMenuLayout),
           new PropertyMetadata(OnChangedItemTemplate));

        public static readonly DependencyProperty MenuItemListBoxItemContainerStyleProperty = DependencyProperty.Register("MenuItemListBoxItemContainerStyle", typeof(Style), typeof(SideMenuLayout),
            new PropertyMetadata(OnChangedItemContainerStyle));

        public static readonly DependencyProperty MenuFooterProperty = DependencyProperty.Register("MenuFooter", typeof(object), typeof(SideMenuLayout),
            new PropertyMetadata(OnchagedFooter));

        public static readonly DependencyProperty MenuHeaderProperty = DependencyProperty.Register("MenuHeader", typeof(object), typeof(SideMenuLayout),
            new PropertyMetadata(OnChangedHeader));

        public object MenuFooter
        {
            get => GetValue(MenuFooterProperty);
            set => SetValue(MenuFooterProperty, value);
        }

        public object MenuHeader
        {
            get => GetValue(MenuHeaderProperty);
            set => SetValue(MenuHeaderProperty, value);
        }

        public DataTemplate MenuItemTemplate
        {
            get => (DataTemplate)GetValue(MenuItemTemplateProperty);
            set => SetValue(MenuItemTemplateProperty, value);
        }

        public Style MenuItemListBoxItemContainerStyle
        {
            get => (Style)GetValue(MenuItemListBoxItemContainerStyleProperty);
            set => SetValue(MenuItemListBoxItemContainerStyleProperty, value);
        }
        private static void OnchagedFooter(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((SideMenuLayout)d).ChangedFooter(e.NewValue);
        }

        private static void OnChangedHeader(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((SideMenuLayout)d).ChangeMenuHeader(e.NewValue);
        }

        private static void OnChangedItemContainerStyle(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((SideMenuLayout)d).ChangeItemContainerStyle((Style)e.NewValue);
        }

        private static void OnChangedItemTemplate(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((SideMenuLayout)d).ChangeItemTemplate((DataTemplate)e.NewValue);
        }

        public SideMenuLayout()
        {
            this.InitializeComponent();
            this.Loaded += SideMenuLayout_Loaded;
        }

        private void SideMenuLayout_Loaded(object sender, RoutedEventArgs e)
        {
            SetTemplate(MenuItemTemplate);
            SetItemContainerStyle(MenuItemListBoxItemContainerStyle);

            IMenuManagerService? sidmenuSerivce = AwesUiKit.GetServiceProvider().GetService<IMenuManagerService>();

            if (sidmenuSerivce != null)
            {
                var menus = sidmenuSerivce.GetMenuItems();
                menuList.ItemsSource = menus;
                menuList.SelectedItem = menus.FirstOrDefault();
            }

            //WeakReferenceMessenger.Default.Register<SideMenuAddMessage>(this, (r, m) =>
            //{
            //    menuList.Items.Add((IMenuItem)m);
            //});

            //WeakReferenceMessenger.Default.Register<SideMenuNavigateMessage>(this, (r, m) =>
            //{
            //    menuList.SelectedItem = menuList.Items.FirstOrDefault(o => ((IMenuItem)o).Header == m.Header);
            //});
        }

        private void SetTemplate(DataTemplate dt)
        {
            if (dt != null)
            {
                menuList.ItemTemplate = dt;
            }
            else
            {
                menuList.ItemTemplate = FindResource("dt_default_ItemTemplate") as DataTemplate;
            }
        }

        private void SetItemContainerStyle(Style style)
        {
            if (style != null)
            {
                menuList.ItemContainerStyle = style;
            }
            else
            {
                menuList.ItemContainerStyle = FindResource("style_default_ItemContainerStyle") as Style;
            }
        }

        private void ChangeItemTemplate(DataTemplate newValue)
        {
            SetTemplate(newValue);
        }

        private void ChangeItemContainerStyle(Style newValue)
        {
            SetItemContainerStyle(newValue);
        }

        private void ChangedFooter(object newValue)
        {
            footer.Content = newValue;
        }

        private void ChangeMenuHeader(object newValue)
        {
            header.Content = newValue;
        }

    }
}
