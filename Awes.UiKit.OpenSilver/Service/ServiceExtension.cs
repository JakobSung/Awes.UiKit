using Awes.UiKit.OpenSilver.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Awes.UiKit.OpenSilver
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddAwesUiKitService(this IServiceCollection services)
        {
            services.AddSingleton<ILayoutManagerService, LayoutManagerService>();
            return services;
        }
    }
}
