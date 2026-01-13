using System;
using Microsoft.Extensions.Hosting;

namespace Awes.UiKit.Wpf
{
    public class WpfHost : IHost
    {
        private IServiceProvider? _serviceProvider;
        private bool _started;

        public IServiceProvider Services => _serviceProvider ?? throw new InvalidOperationException("Host not initialized. Call Initialize before use.");

        internal void Initialize(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void Dispose()
        {
            if (_serviceProvider is IDisposable d)
            {
                d.Dispose();
            }
        }

        public Task StartAsync(CancellationToken cancellationToken = default)
        {
            _started = true;
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken = default)
        {
            _started = false;
            return Task.CompletedTask;
        }
    }
}
