using Awes.UiKit.OpenSilver.Message;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


namespace Awes.UiKit.OpenSilver.Service
{
    public class LayoutManagerService : ILayoutManagerService
    {
        public string Test { get; set; }
        public void CallTest(string test)
        {
            Test = Test + Environment.NewLine + test;
            WeakReferenceMessenger.Default.Send<SideMenuLayoutMessage>(new SideMenuLayoutMessage() { Message = test });
        }
    }


    public interface ILayoutManagerService
    {
        string Test { get; set; }   
        void CallTest(string test);
    }
}
