
# Awes.UiKit

| Package | NuGet | Downloads | Build |
|--------|-------|-----------|-------|
| Awes.UiKit.OpenSilver | [![NuGet Version](https://img.shields.io/nuget/v/Awes.UiKit.OpenSilver.svg)](https://www.nuget.org/packages/Awes.UiKit.OpenSilver/) | [![NuGet Downloads](https://img.shields.io/nuget/dt/Awes.UiKit.OpenSilver.svg)](https://www.nuget.org/packages/Awes.UiKit.OpenSilver/) | [![Build Status](https://github.com/JakobSung/Awes.UiKit/actions/workflows/nuget-publish.yml/badge.svg)](https://github.com/JakobSung/Awes.UiKit/actions/workflows/nuget-publish.yml) |
| Awes.UiKit.Wpf | [![NuGet Version](https://img.shields.io/nuget/v/Awes.UiKit.Wpf.svg)](https://www.nuget.org/packages/Awes.UiKit.Wpf/) | [![NuGet Downloads](https://img.shields.io/nuget/dt/Awes.UiKit.Wpf.svg)](https://www.nuget.org/packages/Awes.UiKit.Wpf/) | [![Build Status](https://github.com/JakobSung/Awes.UiKit/actions/workflows/nuget-publish.yml/badge.svg)](https://github.com/JakobSung/Awes.UiKit/actions/workflows/nuget-publish.yml) |

Minimal UI Kit for **OpenSilver** and **WPF**.

## Packages

### Awes.UiKit.OpenSilver

OpenSilver integration and hosting layer.

- Targets: `netstandard2.0`, `net10.0`
- Includes OpenSilver host builders and OpenSilver-specific services

See: `Awes.UiKit.OpenSilver/README.NuGet.md`

### Awes.UiKit.Wpf

WPF integration and hosting layer.

- Target: `net10.0-windows`
- Includes `WPFHostBuilder` and WPF-specific services

See: `Awes.UiKit.Wpf/README.NuGet.md`

## Install

```powershell
PM> Install-Package Awes.UiKit.OpenSilver
PM> Install-Package Awes.UiKit.Wpf
```

Or:

```powershell
dotnet add package Awes.UiKit.OpenSilver
dotnet add package Awes.UiKit.Wpf
```

## Samples

- OpenSilver sample: `Awes.UiKit.OpenSilver.Sample`
- WPF sample: `Awes.UiKit.Wpf.Sample`

## License

MIT. See `LICENSE`.
