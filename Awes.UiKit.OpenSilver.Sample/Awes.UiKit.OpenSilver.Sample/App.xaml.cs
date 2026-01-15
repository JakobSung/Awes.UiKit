using Awes.UiKit;
using Awes.UiKit.OpenSilver.Sample.View;
using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Awes.UiKit.OpenSilver.Builder;
using Awes.UiKit.OpenSilver.Sample.ViewModel;

namespace Awes.UiKit.OpenSilver.Sample
{
    public sealed partial class App : Application
    {
        public static IServiceProvider ServiceProvider => AwesUiKit.GetServiceProvider();

        public App()
        {
            this.InitializeComponent();

            try
            {
                OpenSilverHostBuilder.CreateBuilder()
                    .ConfigureServices(services =>
                    {
                        services.AddScoped<DashBoardView>();
                        services.AddScoped<TestContentView>();
                        services.AddScoped<TestViewModel>();
                    })
                    .ConfigureStartPage<MainPage>()
                    .Build();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to initialize app: {ex.Message}\n\n{ex.StackTrace}");
            }
        }
    }
}
