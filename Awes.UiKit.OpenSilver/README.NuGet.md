# Awes.UiKit.OpenSilver

[![NuGet Version](https://img.shields.io/nuget/v/Awes.UiKit.OpenSilver.svg)](https://www.nuget.org/packages/Awes.UiKit.OpenSilver/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Awes.UiKit.OpenSilver.svg)](https://www.nuget.org/packages/Awes.UiKit.OpenSilver/)
[![Build Status](https://github.com/JakobSung/Awes.UiKit/actions/workflows/nuget-publish.yml/badge.svg)](https://github.com/JakobSung/Awes.UiKit/actions/workflows/nuget-publish.yml)

Minimal integration layer for **OpenSilver** applications.

- Targets: `netstandard2.0`, `net10.0`
- Provides hosting builders for OpenSilver and Blazor WebAssembly
- Integrates with the layout manager and menu system from `Awes.UiKit.Core`

> This package focuses on OpenSilver hosting, DI integration, and services.

## Install

```powershell
PM> Install-Package Awes.UiKit.OpenSilver
# or
> dotnet add package Awes.UiKit.OpenSilver
```

## Quick Start

### 1. Blazor WebAssembly + OpenSilver (net10.0)

```csharp
using Awes.UiKit;
using Awes.UiKit.OpenSilver.Builder;
using Awes.UiKit.OpenSilver.Service;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    public static async Task Main(string[] args)
    {
        // Create default WASM host with root component
        var kit = OpenSilverWasmHostBuilder.CreateHost<App>(args);

        // Register UI Kit services and app-specific services
        kit.ConfigureServices(services =>
        {
            services.AddSingleton<ILayoutManagerService, LayoutManagerService>();

            services.AddScoped<DashBoardView>();
            services.AddScoped<TestContentView>();
            services.AddScoped<TestViewModel>();
        });

        var host = kit.Build();
        await host.RunAsync();
    }
}
```

### 2. OpenSilver application startup (App.xaml.cs)

```csharp
using Awes.UiKit;
using Awes.UiKit.OpenSilver.Builder;
using Awes.UiKit.OpenSilver.Service;
using Microsoft.Extensions.DependencyInjection;

public sealed partial class App : Application
{
    public App()
    {
        this.InitializeComponent();

        OpenSilverHostBuilder.CreateBuilder()
            .ConfigureServices(services =>
            {
                services.AddSingleton<ILayoutManagerService, LayoutManagerService>();

                services.AddScoped<DashBoardView>();
                services.AddScoped<TestContentView>();
                services.AddScoped<TestViewModel>();
            })
            .ConfigureStartPage<MainPage>()
            .Build();
    }
}
```

### 3. Register menus in your page

```csharp
using Awes.UiKit;
using Awes.UiKit.Service;

public partial class MainPage : Page
{
    private bool _menuInitialized;

    public MainPage()
    {
        InitializeComponent();
        Loaded += Page_Loaded;
    }

    private void Page_Loaded(object sender, RoutedEventArgs e)
    {
        if (_menuInitialized)
        {
            return;
        }

        _menuInitialized = true;

        var serviceProvider = AwesUiKit.GetServiceProvider();
        var layoutService = serviceProvider?.GetService(typeof(ILayoutManagerService)) as ILayoutManagerService;

        layoutService?.AddMenu("Dashboard", typeof(DashBoardView), typeof(TestViewModel));
        layoutService?.AddMenu("Test", typeof(TestContentView), typeof(TestViewModel));
    }
}
```

## Dependencies

- OpenSilver 3.x
- Microsoft.Extensions.DependencyInjection
- Awes.UiKit.Core

## License

MIT

Source & issues: https://github.com/JakobSung/Awes.UiKit
