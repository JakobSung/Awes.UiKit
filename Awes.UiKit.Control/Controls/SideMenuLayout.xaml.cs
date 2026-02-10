using Awes.UiKit.Model;
using Awes.UiKit;
using Awes.UiKit.Service;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;

namespace Awes.UiKit.Control
{
    /// <summary>
    /// SideMenuLayout.xaml에 대한 상호 작용 논리
    /// OpenSilver와 WPF에서 공통으로 사용 가능한 컨트롤
    /// </summary>
    public partial class SideMenuLayout : UserControl
    {
        public static readonly DependencyProperty MenuItemTemplateProperty = DependencyProperty.Register(
            "MenuItemTemplate", 
            typeof(DataTemplate), 
            typeof(SideMenuLayout),
            new PropertyMetadata(OnChangedItemTemplate));

        public static readonly DependencyProperty MenuItemListBoxItemContainerStyleProperty = DependencyProperty.Register(
            "MenuItemListBoxItemContainerStyle", 
            typeof(Style), 
            typeof(SideMenuLayout),
            new PropertyMetadata(OnChangedItemContainerStyle));

        public static readonly DependencyProperty MenuFooterProperty = DependencyProperty.Register(
            "MenuFooter", 
            typeof(object), 
            typeof(SideMenuLayout),
            new PropertyMetadata(OnChangedFooter));

        public static readonly DependencyProperty MenuHeaderProperty = DependencyProperty.Register(
            "MenuHeader", 
            typeof(object), 
            typeof(SideMenuLayout),
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

        private static void OnChangedFooter(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((SideMenuLayout)d).ChangedFooter(e.NewValue);
        }

        private static void OnChangedHeader(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((SideMenuLayout)d).ChangeMenuHeader(e.NewValue);
        }

        private static void OnChangedItemContainerStyle(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((SideMenuLayout)d).ChangeItemContainerStyle((Style?)e.NewValue);
        }

        private static void OnChangedItemTemplate(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((SideMenuLayout)d).ChangeItemTemplate((DataTemplate?)e.NewValue);
        }

        private ILayoutManagerService? _layoutService;

        public SideMenuLayout()
        {
            this.InitializeComponent();
            this.Loaded += SideMenuLayout_Loaded;
            this.Unloaded += SideMenuLayout_Unloaded;
            menuList.SelectionChanged += MenuList_SelectionChanged;
        }

        private void SideMenuLayout_Loaded(object sender, RoutedEventArgs e)
        {
            SetTemplate(MenuItemTemplate);
            SetItemContainerStyle(MenuItemListBoxItemContainerStyle);

            var serviceProvider = AwesUiKit.GetServiceProvider();
            if (serviceProvider != null)
            {
                try
                {
                    _layoutService = serviceProvider.GetService(typeof(ILayoutManagerService)) as ILayoutManagerService;

                    if (_layoutService != null)
                    {
                        var menus = _layoutService.GetMenuItems();
                        menuList.ItemsSource = menus;
                        
                        // 서비스의 현재 메뉴와 동기화
                        if (_layoutService.CurrentMenu != null)
                        {
                            menuList.SelectedItem = _layoutService.CurrentMenu;
                        }
                        else
                        {
                            menuList.SelectedItem = menus.FirstOrDefault();
                            _layoutService.CurrentMenu = menuList.SelectedItem as IMenuItem;
                        }

                        if (_layoutService is INotifyPropertyChanged notify)
                        {
                            notify.PropertyChanged += LayoutService_PropertyChanged;
                        }
                    }
                }
                catch (Exception)
                {
                    // ignore
                }
            }
        }

        private void SideMenuLayout_Unloaded(object sender, RoutedEventArgs e)
        {
            if (_layoutService is INotifyPropertyChanged notify)
            {
                notify.PropertyChanged -= LayoutService_PropertyChanged;
            }
        }

        private void LayoutService_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ILayoutManagerService.CurrentMenu))
            {
                if (menuList.SelectedItem != _layoutService?.CurrentMenu)
                {
                    menuList.SelectedItem = _layoutService?.CurrentMenu;
                }
            }
        }

        private void MenuList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_layoutService != null && menuList.SelectedItem != null)
            {
                var selectedItem = menuList.SelectedItem as IMenuItem;
                if (_layoutService.CurrentMenu != selectedItem)
                {
                    _layoutService.CurrentMenu = selectedItem;
                }
            }
        }

        private void SetTemplate(DataTemplate? dt)
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

        private void SetItemContainerStyle(Style? style)
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

        private void ChangeItemTemplate(DataTemplate? newValue)
        {
            SetTemplate(newValue);
        }

        private void ChangeItemContainerStyle(Style? newValue)
        {
            SetItemContainerStyle(newValue);
        }

        private void ChangedFooter(object? newValue)
        {
            footer.Content = newValue;
        }

        private void ChangeMenuHeader(object? newValue)
        {
            header.Content = newValue;
        }
    }
}
