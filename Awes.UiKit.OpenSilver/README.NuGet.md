# Awes.UiKit.OpenSilver




[![NuGet Version](https://img.shields.io/nuget/v/Awes.UiKit.OpenSilver.svg)](https://www.nuget.org/packages/Awes.UiKit.OpenSilver/)
[![Build Status](https://github.com/JakobSung/Awes.UiKit/actions/workflows/nuget-publish.yml/badge.svg)](https://github.com/JakobSung/Awes.UiKit/actions/workflows/nuget-publish.yml)

Minimal UI Kit for OpenSilver (netstandard2.0, net9.0)

## Features
- Side menu layout (ListBox + content region)
- LayoutManagerService (menu registration + navigation broadcast)
- DI helpers for OpenSilver apps

## Install
```
PM> Install-Package Awes.UiKit.OpenSilver
# or
> dotnet add package Awes.UiKit.OpenSilver
```

## Quick Start

### net9 (Blazor WebAssembly + OpenSilver)
```csharp
using Awes.UiKit.OpenSilver.Builder;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    public static async Task Main(string[] args)
    {
        // Create default WASM host with root component
        var kit = AwesUiKitWasmHostBuilder.CreateHost<App>(args);

        // Register app-specific services (Views / ViewModels etc.)
        kit.ConfigureServices(services =>
        {
            services.AddScoped<DashBoardView>();
            services.AddScoped<TestContentView>();
            services.AddScoped<TestViewModel>();
        });

        // Build host and initialize global ServiceProvider
        var host = kit.Build();
        await host.RunAsync();
    }
}
```

### netstandard2.0
```csharp
using Awes.UiKit.OpenSilver.Service;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
// Register required services for UI Kit
services.AddSingleton<ILayoutManagerService, LayoutManagerService>();

// App-specific registrations
services.AddScoped<DashBoardView>();
services.AddScoped<TestContentView>();
services.AddScoped<TestViewModel>();

var provider = services.BuildServiceProvider();
// var layout = provider.GetRequiredService<ILayoutManagerService>();
```

In XAML host page, place your side menu layout control and bind menu items.

## Dependencies
- OpenSilver 3.x
- Microsoft.Extensions.DependencyInjection
- CommunityToolkit.Mvvm (messaging)

## License
MIT

Source & issues: https://github.com/JakobSung/Awes.UiKit
