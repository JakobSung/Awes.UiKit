using Awes.UiKit.Model;
using System.Collections.ObjectModel;
using System.Windows;

namespace Awes.UiKit.Service
{
    public class LayoutManagerService : ILayoutManagerService
    {
        private ObservableCollection<IMenuItem> _menuItems { get; set; } = new ObservableCollection<IMenuItem>();

        public ObservableCollection<IMenuItem> GetMenuItems()
        {
            return _menuItems;
        }

        public virtual void AddMenu(string header, Type view, Type viewModel)
        {
            FrameworkElement v = global::Awes.UiKit.AwesUiKit.GetServiceProvider()?.GetService(view) as FrameworkElement
                ?? throw new InvalidOperationException("View not resolved");
            var vm = global::Awes.UiKit.AwesUiKit.GetServiceProvider()?.GetService(viewModel)
                ?? throw new InvalidOperationException("ViewModel not resolved");
            v.DataContext = vm;

            MenuItem menu = new MenuItem(header, v);
            _menuItems.Add(menu);

            
        }

        public virtual void Navigate(string header)
        {
            
        }
    }

    public interface ILayoutManagerService
    {
        ObservableCollection<IMenuItem> GetMenuItems();
        void AddMenu(string header, Type view, Type viewModel);
    }
}
