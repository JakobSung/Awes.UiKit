using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Awes.UiKit
{
    public class AwesUiKit
    {
        private static IServiceProvider? ServiceProvider { get; set; } = null;

        public static void RegistServiceProvdier(IServiceProvider provider)
        {
            ServiceProvider = provider;
        }

        public static IServiceProvider? GetServiceProvider()
        {
            return ServiceProvider;
        }
    }
}
