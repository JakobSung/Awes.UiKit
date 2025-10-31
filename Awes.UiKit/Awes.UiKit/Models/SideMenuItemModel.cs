using Awes.UiKit.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Awes.UiKit.Models
{
    public class SideMenuItemModel : IMenuModel
    {
        public string Header { get; set; }
        public object ContentView { get; set; }
        public SideMenuItemModel(string header, object contentView)
        {
            Header = header;
            ContentView = contentView;
        }
    }
}
