using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
// using Awes.UiKit.Service;

namespace Awes.UiKit.Wpf
{
    public class WPFHostBuilder
    {
        private Application? _app = null;
        private WpfHost _host = new WpfHost();
        private Window? _mainWindow = null;
        private ServiceCollection _services = new ServiceCollection();
        private object? _mainVm = null;

        private Type _mainWindowType = null;

        public WPFHostBuilder(Application app)
        {
            _app = app;
            _app.Startup += App_Startup;
            _app.Exit += App_Exit;

            _host = new WpfHost();
        }

        public IServiceCollection Services => _services;

        private void App_Exit(object sender, ExitEventArgs e)
        {
            // Trigger graceful stop
            _ = _host.StopAsync();
        }

        private void App_Startup(object sender, StartupEventArgs e)
        {
            if (_mainWindowType == null)
            {
                throw new InvalidOperationException("MainWindow is not configured. Please call ConfigureStartWindow<T> to configure the main window.");
            }

            _mainWindow ??= (Window)_host.Services.GetRequiredService(_mainWindowType);
            _mainWindow.DataContext = _mainVm;
            _mainWindow.Show();
        }

        public WPFHostBuilder ConfigureStartWindow<T>(object? mainVm = null) where T : Window
        {
            _mainWindowType = typeof(T);
            _services.AddTransient<T>();
            _mainVm = mainVm;
            return this;
        }

        public WPFHostBuilder ConfigureServices(Action<IServiceCollection> action)
        {
            // this.Services.AddSingleton<SideMenuLayoutManagerService>();
            action.Invoke(this.Services);
            return this;
        }

        public WpfHost Build()
        {
            var serviceProvider = _services.BuildServiceProvider();
            _host.Initialize(serviceProvider);
            return _host;
        }
    }

    
}
