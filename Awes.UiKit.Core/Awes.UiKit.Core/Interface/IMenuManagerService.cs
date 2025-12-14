using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Awes.UiKit.Interface
{
    public interface IMenuManagerService
    {
        public ObservableCollection<IMenuModel> MenuItems { get; set; }

        public ObservableCollection<IMenuModel> GetMenuItems()
        {
            return MenuItems;
        }

        public void AddMenu(string header, Type view, Type viewModel)
        {
           
        }

        public void Navigate(string header)
        {
            
        }
    }
}
