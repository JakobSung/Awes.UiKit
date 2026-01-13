using Microsoft.Extensions.DependencyInjection;
using System;

namespace Awes.UiKit
{
    public static class AwesUiKit
    {
        private static IServiceProvider? _serviceProvider;
        private static IServiceCollection? _services;

        /// <summary>
        /// 서비스 컬렉션을 직접 설정합니다 (초기 부트스트랩용)
        /// </summary>
        public static void SetServices(IServiceCollection services)
        {
            _services = services ?? throw new ArgumentNullException(nameof(services));
        }

        /// <summary>
        /// 서비스 프로바이더를 서비스 컬렉션과 함께 등록합니다
        /// </summary>
        public static void RegisterServiceProvider(IServiceProvider provider, IServiceCollection services)
        {
            _services = services;
            _serviceProvider = provider;
        }

        /// <summary>
        /// 서비스 프로바이더를 가져옵니다
        /// </summary>
        public static IServiceProvider GetServiceProvider()
        {
            return _serviceProvider ?? throw new InvalidOperationException("ServiceProvider not registered. Call RegisterServiceProvider() first.");
        }
    }
}
