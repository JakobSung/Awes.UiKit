using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Awes.UiKit.Interface
{
    public interface IMenuModel
    {
        string Header { get; set; }

        object ContentView { get; set; }
    }
}
