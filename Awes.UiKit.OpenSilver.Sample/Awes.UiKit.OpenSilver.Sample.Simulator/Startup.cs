using Microsoft.Extensions.DependencyInjection;
using OpenSilver.Simulator;
using System;
using Awes.UiKit;

namespace Awes.UiKit.OpenSilver.Sample.Simulator
{
    internal static class Startup
    {
        [STAThread]
        static int Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddAwesUiKitOpenSilverServices();
            AwesUiKit.SetServices(services);
            var provider = services.BuildServiceProvider();
            AwesUiKit.RegisterServiceProvider(provider, services);
            return SimulatorLauncher.Start(typeof(App));
        }
    }
}
