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

## Dependencies

- .NET 10.0
- Microsoft.Extensions.DependencyInjection
- Awes.UiKit.Core

## License

MIT

Source & issues: https://github.com/JakobSung/Awes.UiKit
