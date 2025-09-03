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
        private static IServiceProvider _serviceProvider { get; set; }

        public static void RegistServiceProvdier(IServiceProvider provider)
        {
            _serviceProvider = provider;
        }

        public static IServiceProvider GetServiceProvider()
        {
            return _serviceProvider;
        }
    }
}
