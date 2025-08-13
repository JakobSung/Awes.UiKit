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
        public static IServiceCollection AddAwesUiKit(this IServiceCollection services)
        {
            // 서비스를 DI 컨테이너에 등록합니다.
            // 여기서는 Scoped 수명 주기를 사용했습니다.
            //services.AddScoped<IMyService, MyService>();

            // 여기에 다른 서비스들도 추가할 수 있습니다.
            // services.AddTransient<IOtherService, OtherService>();

            return services;
        }
    }
}
