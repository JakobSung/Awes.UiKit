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

## NuGet Package Metadata

```xml
<PropertyGroup>
  <TargetFramework>net10.0-windows</TargetFramework>
  <EnableWindowsTargeting>true</EnableWindowsTargeting>
  <Nullable>enable</Nullable>
  <UseWPF>true</UseWPF>
  <ImplicitUsings>enable</ImplicitUsings>           

  <!-- NuGet metadata -->
  <PackageId>Awes.UiKit.Wpf</PackageId>
  <Version>0.1.0</Version>
  <Authors>Awes</Authors>
  <Company>Awes</Company>
  <Description>Minimal integration layer for **WPF** applications.</Description>
  <PackageTags>wpf;ui;layout;menu;mvvm;xaml</PackageTags>
  <RepositoryUrl>https://github.com/JakobSung/Awes.UiKit</RepositoryUrl>
  <RepositoryType>git</RepositoryType>
  <PackageProjectUrl>https://github.com/JakobSung/Awes.UiKit</PackageProjectUrl>
  <PackageLicenseExpression>MIT</PackageLicenseExpression>
  <PackageReadmeFile>README.NuGet.md</PackageReadmeFile>
  <IncludeSymbols>true</IncludeSymbols>
  <SymbolPackageFormat>snupkg</SymbolPackageFormat>
  <GenerateDocumentationFile>true</GenerateDocumentationFile>
  <GeneratePackageOnBuild>true</GeneratePackageOnBuild>
</PropertyGroup>

<ItemGroup>
  <PackageReference Include="Microsoft.Extensions.Hosting.Abstractions" Version="10.0.0" />
  <PackageReference Include="Microsoft.Extensions.DependencyInjection" Version="10.0.0" />
</ItemGroup>

<ItemGroup>
  <ProjectReference Include="..\Awes.UiKit.Control\Awes.UiKit.Control.csproj" />
  <ProjectReference Include="..\Awes.UiKit.Core\Awes.UiKit.Core\Awes.UiKit.Core.csproj" />
</ItemGroup>

<ItemGroup>
  <None Include="README.NuGet.md" Pack="true" PackagePath="/" />
  <None Include="..\LICENSE" Pack="true" PackagePath="/" />
</ItemGroup>
