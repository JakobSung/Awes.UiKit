using System;
using System.Collections.Generic;
using System.Text;

namespace Awes.UiKit.OpenSilver.Model
{
    public interface IMenuItem
    {
        string Header { get; set; }

        object ContentView { get; set; }

    }

    public class MenuItem : IMenuItem
    {
        public string Header { get; set; }
        public object ContentView { get; set; }
        public MenuItem(string header, object contentView)
        {
            Header = header;
            ContentView = contentView;
        }
    }
}
