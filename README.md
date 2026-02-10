# Awes.UiKit

| Package               | NuGet | Downloads | Build |
|-----------------------|-------|-----------|-------|
| Awes.UiKit.OpenSilver | [![NuGet Version](https://img.shields.io/nuget/v/Awes.UiKit.OpenSilver.svg)](https://www.nuget.org/packages/Awes.UiKit.OpenSilver/) | [![NuGet Downloads](https://img.shields.io/nuget/dt/Awes.UiKit.OpenSilver.svg)](https://www.nuget.org/packages/Awes.UiKit.OpenSilver/) | [![Build Status](https://github.com/JakobSung/Awes.UiKit/actions/workflows/nuget-publish.yml/badge.svg)](https://github.com/JakobSung/Awes.UiKit/actions/workflows/nuget-publish.yml) |
| Awes.UiKit.Wpf        | [![NuGet Version](https://img.shields.io/nuget/v/Awes.UiKit.Wpf.svg)](https://www.nuget.org/packages/Awes.UiKit.Wpf/) | [![NuGet Downloads](https://img.shields.io/nuget/dt/Awes.UiKit.Wpf.svg)](https://www.nuget.org/packages/Awes.UiKit.Wpf/) | [![Build Status](https://github.com/JakobSung/Awes.UiKit/actions/workflows/nuget-publish.yml/badge.svg)](https://github.com/JakobSung/Awes.UiKit/actions/workflows/nuget-publish.yml) |

**A UI Kit designed to accelerate modern .NET application development for OpenSilver and WPF.**

This project aims to provide a streamlined development experience by integrating .NET's **Generic Host** for dependency injection, configuration, and service management, along with interactive UI components.

## Packages

### Awes.UiKit.OpenSilver

Provides a hosting layer and services for **OpenSilver** applications, enabling a modern, DI-centric architecture.

- **Targets**: `netstandard2.0`, `net10.0`
- **Features**:
  - `OpenSilverHostBuilder` and `OpenSilverWasmHostBuilder` for easy setup.
  - Seamless integration with `Microsoft.Extensions.DependencyInjection`.
  - Manages application lifecycle and services through the Generic Host pattern.

See: `Awes.UiKit.OpenSilver/README.NuGet.md`

### Awes.UiKit.Wpf

Provides a hosting layer and services for **WPF** desktop applications, bringing modern development practices to the desktop.

- **Target**: `net10.0-windows`
- **Features**:
  - `WPFHostBuilder` to configure and run WPF apps with a Generic Host.
  - Simplifies dependency injection for Windows, ViewModels, and Services.
  - Unifies the application structure with modern .NET ecosystems.

See: `Awes.UiKit.Wpf/README.NuGet.md`

## Shared Components

- **Awes.UiKit.Core**: Contains shared services, models, and the core `ILayoutManagerService` for menu navigation.
- **Awes.UiKit.Control**: Provides shared, interactive UI components like `SideMenuLayout` that work across both OpenSilver and WPF.

## Install

```powershell
PM> Install-Package Awes.UiKit.OpenSilver
PM> Install-Package Awes.UiKit.Wpf
```

Or use the .NET CLI:

```powershell
dotnet add package Awes.UiKit.OpenSilver
dotnet add package Awes.UiKit.Wpf
```

## Quick Start

### OpenSilver

Browser (`Program.cs`):

```csharp
using Awes.UiKit.OpenSilver.Builder;

var host = OpenSilverWasmHostBuilder.CreateHost<App>(args);
await host.RunAsync();
```

App startup (`App.xaml.cs`):

```csharp
using Awes.UiKit.OpenSilver.Builder;

OpenSilverHostBuilder.CreateBuilder()
    .ConfigureStartPage<MainPage>()
    .Build();
```

Register menus (`MainPage.xaml.cs`):

```csharp
using Awes.UiKit;
using Awes.UiKit.Service;

public partial class MainPage : Page
{
    private void Page_Loaded(object sender, RoutedEventArgs e)
    {
        var sp = AwesUiKit.GetServiceProvider();
        var lm = sp?.GetService(typeof(ILayoutManagerService)) as ILayoutManagerService;

        lm?.AddMenu("DashBoard", typeof(DashBoardView), typeof(TestViewModel));
        lm?.AddMenu("Test", typeof(TestContentView), typeof(TestViewModel));
    }
}
```

More: `Awes.UiKit.OpenSilver/README.NuGet.md`

### WPF

App startup (`App.xaml.cs`):

```csharp
using System.Windows;

public partial class App : Application
{
	public App()
        {
            WpfHost host = new WPFHostBuilder(this)
                                    .ConfigureStartWindow<MainWindow, MainViewModel>()
                                    .ConfigureServices(_ => { })
                                    .Build();

            Task.Run(async () => await host.RunAsync());
        }
}
```

Register menus (e.g., `MainPage.xaml.cs`):

```csharp
using Awes.UiKit;
using Awes.UiKit.Service;

public partial class MainPage : Page
{
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

        var serviceProvider = AwesUiKit.GetServiceProvider();
        var layoutService = serviceProvider?.GetService(typeof(ILayoutManagerService)) as ILayoutManagerService;

        layoutService?.AddMenu("Dashboard", typeof(DashBoardView), typeof(TestViewModel));
        layoutService?.AddMenu("Test", typeof(TestContentView), typeof(TestViewModel));
    }
}
```

More: `Awes.UiKit.Wpf/README.NuGet.md`

## License

MIT. See `LICENSE`.
