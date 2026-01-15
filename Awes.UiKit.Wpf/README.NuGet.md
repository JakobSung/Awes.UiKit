# Awes.UiKit.Wpf

[![NuGet Version](https://img.shields.io/nuget/v/Awes.UiKit.Wpf.svg)](https://www.nuget.org/packages/Awes.UiKit.Wpf/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Awes.UiKit.Wpf.svg)](https://www.nuget.org/packages/Awes.UiKit.Wpf/)
[![Build Status](https://github.com/JakobSung/Awes.UiKit/actions/workflows/nuget-publish.yml/badge.svg)](https://github.com/JakobSung/Awes.UiKit/actions/workflows/nuget-publish.yml)

Minimal integration layer for **WPF** applications.

- Target: `net10.0-windows`
- Provides a WPF hosting model with `WPFHostBuilder` and `WpfHost`
- Integrates with the layout manager and menu system from `Awes.UiKit.Core`

> This package focuses on WPF hosting, DI integration, and services.

## Install

```powershell
PM> Install-Package Awes.UiKit.Wpf
# or
> dotnet add package Awes.UiKit.Wpf
```

## Quick Start

### 1. WPF application startup (App.xaml.cs)

```csharp
using Awes.UiKit;
using Awes.UiKit.Wpf.Builder;
using Awes.UiKit.Wpf.Service;
using Microsoft.Extensions.DependencyInjection;

public partial class App : Application
{
    public App()
    {
        this.InitializeComponent();

        WpfHostBuilder.CreateBuilder()
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

### 2. Register menus in your page

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

- .NET 10.0
- Microsoft.Extensions.DependencyInjection
- Awes.UiKit.Core

## License

MIT

Source & issues: https://github.com/JakobSung/Awes.UiKit
