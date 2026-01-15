using Awes.UiKit.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Awes.UiKit.Service
{
    public class SideMenuLayoutManagerService : IMenuManagerService
    {
        public ObservableCollection<IMenuModel> MenuItems { get; set; } = new ObservableCollection<IMenuModel>();
    }
}
