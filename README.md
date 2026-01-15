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

App startup (`App.xaml.cs`):

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
            })
            .ConfigureStartPage<MainPage>()
            .Build();
    }
}
```

Register menus (e.g., `MainPage.xaml.cs`):

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

More: `Awes.UiKit.OpenSilver/README.NuGet.md`

### WPF

App startup (`App.xaml.cs`):

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
            })
            .ConfigureStartPage<MainPage>()
            .Build();
    }
}
```

Register menus (e.g., `MainPage.xaml.cs`):

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

More: `Awes.UiKit.Wpf/README.NuGet.md`

## License

MIT. See `LICENSE`.
