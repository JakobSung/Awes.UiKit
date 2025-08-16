using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Awes.UiKit.OpenSilver.Message
{
    public class SideMenuAddMessage
    {
        public object Message { get; internal set; }
    }

    public class SideMenuNavigateMessage
    {
        public string Header { get; internal set; }
    }
}
