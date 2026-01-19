# Awes.UiKit.OpenSilver


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

In XAML host page, place your side menu layout control and bind menu items.

## Dependencies
- OpenSilver 3.x
- Microsoft.Extensions.DependencyInjection
- CommunityToolkit.Mvvm (messaging)

## License
MIT

Source & issues: https://github.com/JakobSung/Awes.UiKit
