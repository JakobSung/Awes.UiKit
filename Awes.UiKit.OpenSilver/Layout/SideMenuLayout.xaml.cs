using Awes.UiKit.OpenSilver.Message;
using Awes.UiKit.OpenSilver.Model;
using Awes.UiKit.OpenSilver.Service;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Awes.UiKit.OpenSilver.Layout
{
    public partial class SideMenuLayout : UserControl
    {
        public static readonly DependencyProperty MenuItemTemplateProperty = DependencyProperty.Register("MenuItemTemplate", typeof(DataTemplate), typeof(SideMenuLayout),
            new PropertyMetadata(OnChangedItemTemplate));

        public static readonly DependencyProperty MenuItemListBoxItemContainerStyleProperty = DependencyProperty.Register("MenuItemListBoxItemContainerStyle", typeof(Style), typeof(SideMenuLayout),
            new PropertyMetadata(OnChangedItemContainerStyle));

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
            ILayoutManagerService layoutSerivce = AwesUiKit.ServiceProvider.GetService<ILayoutManagerService>();

            menuList.ItemsSource = layoutSerivce.GetMenuItems();
            menuList.SelectedItem = menuList.Items.FirstOrDefault();

            SetTemplate(MenuItemTemplate);
            SetItemContainerStyle(MenuItemListBoxItemContainerStyle);

            WeakReferenceMessenger.Default.Register<SideMenuAddMessage>(this, (r, m) =>
            {
                menuList.Items.Add((IMenuItem)m);
            });

            WeakReferenceMessenger.Default.Register<SideMenuNavigateMessage>(this, (r, m) =>
            {
                menuList.SelectedItem = menuList.Items.FirstOrDefault(o => ((IMenuItem)o).Header == m.Header);
            });
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
    }
}
