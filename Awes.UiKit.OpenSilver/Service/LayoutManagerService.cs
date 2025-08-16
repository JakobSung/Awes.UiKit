using Awes.UiKit.OpenSilver.Message;
using Awes.UiKit.OpenSilver.Model;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;


namespace Awes.UiKit.OpenSilver.Service
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
            FrameworkElement v = AwesUiKit.ServiceProvider.GetService(view) as FrameworkElement;
            var vm = AwesUiKit.ServiceProvider.GetService(viewModel);
            v.DataContext = vm;

            MenuItem menu = new MenuItem(header, v);
            _menuItems.Add(menu);

            WeakReferenceMessenger.Default.Send(new SideMenuAddMessage
            {
                Message = menu
            }); 
        }

        public virtual void Navigate(string header)
        {
            WeakReferenceMessenger.Default.Send(new SideMenuNavigateMessage
            {
                Header = header
            });
        }
    }

    public interface ILayoutManagerService
    {
        ObservableCollection<IMenuItem> GetMenuItems();
        void AddMenu(string header, Type view, Type viewModel);

    }
}
