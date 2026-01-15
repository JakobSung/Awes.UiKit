using System;
using Microsoft.Extensions.Hosting;

namespace Awes.UiKit.Wpf
{
    public class WpfHost : IHost
    {
        public IServiceProvider Services => AwesUiKit.GetServiceProvider() ?? throw new InvalidOperationException("Host not initialized. Call Initialize before use.");

        internal void Initialize(IServiceProvider serviceProvider)
        {
            AwesUiKit.RegisterServiceProvider(serviceProvider);
        }

        public void Dispose()
        {
            
        }

        public Task StartAsync(CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }
    }
}
