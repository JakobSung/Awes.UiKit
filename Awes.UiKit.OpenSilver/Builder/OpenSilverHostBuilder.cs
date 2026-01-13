using Awes.UiKit;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Awes.UiKit.OpenSilver.Builder
{
    /// <summary>
    /// OpenSilver 호스트 빌더 클래스
    /// 시작 페이지와 윈도우 설정을 담당합니다
    /// 서비스는 AwesUiKit.SetServices()를 통해 관리됩니다
    /// </summary>
    public class OpenSilverHostBuilder
    {
        private readonly IServiceCollection _services;
        private Type? _mainPageType = null;

        private OpenSilverHostBuilder(IServiceCollection services)
        {
            _services = services;
        }

        /// <summary>
        /// 시작 페이지를 구성합니다
        /// </summary>
        public OpenSilverHostBuilder ConfigureStartPage<T>() where T : Page
        {
            _mainPageType = typeof(T);
            _services.AddTransient<T>();
            return this;
        }

        /// <summary>
        /// 서비스를 구성합니다 (AwesUiKit에서 관리)
        /// </summary>
        public OpenSilverHostBuilder ConfigureServices(Action<IServiceCollection> configure)
        {
            configure?.Invoke(_services);
            return this;
        }

        /// <summary>
        /// 호스트를 빌드합니다
        /// </summary>
        public void Build()
        {
            if (_mainPageType is null)
            {
                throw new InvalidOperationException("Start page not configured. Call ConfigureStartPage<T>() before Build().");
            }

            var serviceProvider = _services.BuildServiceProvider();
            AwesUiKit.RegisterServiceProvider(serviceProvider, _services);
            var mainPage = (FrameworkElement)serviceProvider.GetRequiredService(_mainPageType);
            Window.Current.Content = mainPage;
        }

        /// <summary>
        /// 새로운 호스트 빌더를 생성합니다
        /// </summary>
        public static OpenSilverHostBuilder CreateBuilder()
        {
            var services = new ServiceCollection();
            services.AddAwesUiKitServices();
            AwesUiKit.SetServices(services);
            return new OpenSilverHostBuilder(services);
        }

    }
}
