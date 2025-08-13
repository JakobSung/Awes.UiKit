using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Awes.UiKit.OpenSilver
{
    public static class AwesUiKit
    {
        internal static IServiceProvider ServiceProvider { get; set; }
        public static void UseAwesUiKit(IServiceProvider provicer)
        {
            ServiceProvider = provicer;
        }
    }
}
