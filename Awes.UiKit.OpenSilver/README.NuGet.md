# Awes.UiKit.OpenSilver

[![NuGet Version](https://img.shields.io/nuget/v/Awes.UiKit.OpenSilver.svg)](https://www.nuget.org/packages/Awes.UiKit.OpenSilver/)
[![Build Status](https://github.com/JakobSung/Awes.UiKit/actions/workflows/nuget-publish.yml/badge.svg)](https://github.com/JakobSung/Awes.UiKit/actions/workflows/nuget-publish.yml)

Minimal UI Kit for OpenSilver (netstandard2.0).

## Features
- Side menu layout (ListBox + content region)
- LayoutManagerService (menu registration + navigation broadcast)
- DI extension: services.AddAwesUiKit()

## Install
```
PM> Install-Package Awes.UiKit.OpenSilver
# or
> dotnet add package Awes.UiKit.OpenSilver
```

## Quick Start
```csharp
var services = new ServiceCollection();
services.AddAwesUiKit();
var provider = services.BuildServiceProvider();
var layout = provider.GetRequiredService<ILayoutManagerService>();
// layout.AddMenu("DashBoard", typeof(DashBoardView), typeof(DashBoardViewModel));
```

In XAML host page, place your side menu layout control and bind menu items.

## Dependencies
- OpenSilver 3.x
- Microsoft.Extensions.DependencyInjection
- CommunityToolkit.Mvvm (messaging)

## License
MIT

Source & issues: https://github.com/JakobSung/Awes.UiKit
