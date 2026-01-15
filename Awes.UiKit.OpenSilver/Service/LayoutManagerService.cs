using Awes.UiKit.Message;
using Awes.UiKit.Model;
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
    /// <summary>
    /// Provides functionality for managing and interacting with a collection of menu items,  including adding new menus
    /// and navigating to specific menu items.
    /// </summary>
    /// <remarks>This service maintains an observable collection of menu items, allowing dynamic updates  to
    /// the menu structure. It supports adding new menu items with associated views and view models,  and facilitates
    /// navigation to specific menu items by their headers.</remarks>
    public class LayoutManagerService : ILayoutManagerService
    {
        private ObservableCollection<IMenuItem> _menuItems { get; set; } = new ObservableCollection<IMenuItem>();

        /// <summary>
        /// Retrieves the collection of menu items.
        /// </summary>
        /// <remarks>The returned collection reflects the current state of the menu items. Changes to the
        /// collection will be reflected in the caller's view, as <see cref="ObservableCollection{T}"/> supports dynamic
        /// updates.</remarks>
        /// <returns>An <see cref="ObservableCollection{T}"/> of <see cref="IMenuItem"/> representing the current menu items.</returns>
        public ObservableCollection<IMenuItem> GetMenuItems()
        {
            return _menuItems;
        }

        /// <summary>
        /// Adds a new menu item to the side menu with the specified header, view, and view model.
        /// </summary>
        /// <remarks>The method resolves the specified <paramref name="view"/> and <paramref
        /// name="viewModel"/> types using the service provider. The resolved view's <see
        /// cref="FrameworkElement.DataContext"/> is set to the resolved view model. A new menu item is created with the
        /// specified header and view, and it is added to the internal menu collection. Additionally, a <see
        /// cref="SideMenuAddMessage"/> is sent via the <see cref="WeakReferenceMessenger"/> to notify listeners of the
        /// new menu item.</remarks>
        /// <param name="header">The text to display as the menu item's header.</param>
        /// <param name="view">The type of the view associated with the menu item. This type must resolve to a <see
        /// cref="FrameworkElement"/>.</param>
        /// <param name="viewModel">The type of the view model to be used as the data context for the view. This type must be resolvable by the
        /// service provider.</param>
        public virtual void AddMenu(string header, Type view, Type viewModel)
        {
            FrameworkElement v = AwesUiKit.GetServiceProvider().GetService(view) as FrameworkElement;
            var vm = AwesUiKit.GetServiceProvider().GetService(viewModel);
            v.DataContext = vm;

            MenuItem menu = new MenuItem(header, v);
            _menuItems.Add(menu);

            WeakReferenceMessenger.Default.Send(new SideMenuAddMessage
            {
                Message = menu
            }); 
        }

        /// <summary>
        /// Sends a navigation message to update the side menu with the specified header.
        /// </summary>
        /// <remarks>This method uses the default instance of <see cref="WeakReferenceMessenger"/> to send
        /// a  <see cref="SideMenuNavigateMessage"/> containing the specified header. Ensure that any  recipients of the
        /// message are properly registered to handle it.</remarks>
        /// <param name="header">The header text to display in the side menu. Cannot be null or empty.</param>
        public virtual void Navigate(string header)
        {
            WeakReferenceMessenger.Default.Send(new SideMenuNavigateMessage
            {
                Header = header
            });
        }
    }

    /// <summary>
    /// Provides functionality for managing layout-related operations, including retrieving menu items  and adding new
    /// menus with associated views and view models.
    /// </summary>
    public interface ILayoutManagerService
    {
        /// <summary>
        /// Retrieves the collection of menu items.
        /// </summary>
        /// <returns></returns>
        ObservableCollection<IMenuItem> GetMenuItems();
        /// <summary>
        /// Adds a new menu item to the application with the specified header, view, and view model.
        /// </summary>
        /// <param name="header">The display text for the menu item.</param>
        /// <param name="view">The type of the view associated with the menu item. This must be a class derived from <see
        /// cref="System.Windows.Controls.UserControl"/>.</param>
        /// <param name="viewModel">The type of the view model associated with the menu item. This must be a class implementing the MVVM
        /// pattern.</param>
        void AddMenu(string header, Type view, Type viewModel);

    }
}
