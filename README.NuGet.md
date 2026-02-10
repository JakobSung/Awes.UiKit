# Awes.UiKit.OpenSilver

Minimal UI Kit for OpenSilver (netstandard2.0) featuring a side menu layout and navigation management.

## Features
- **SideMenuLayout**: A layout control with a side menu (ListBox) and a content region.
- **LayoutManagerService**: Manage menu items and navigation.
- **Navigation Support**: Parameter passing and `INavigationAware` interface support.
- **DI Registration**: Easy service registration extension.

## Install
```powershell
PM> Install-Package Awes.UiKit.OpenSilver
# or
> dotnet add package Awes.UiKit.OpenSilver
```

## Getting Started

### 1. Register Services
In your `Program.cs`:
```csharp
using Awes.UiKit;

public static async Task Main(string[] args)
{
    var builder = WebAssemblyHostBuilder.CreateDefault(args);
    
    // Register Awes.UiKit services
    builder.Services.AddAwesUiKitServices();
    
    // ... other services
    
    await builder.Build().RunAsync();
}
```

### 2. Initialize Menus
Inject `ILayoutManagerService` (e.g., in `App.xaml.cs` or a bootstrapper) and register your views.
```csharp
public App(IServiceProvider serviceProvider)
{
    this.InitializeComponent();
    
    var layoutService = serviceProvider.GetRequiredService<ILayoutManagerService>();
    
    // Add menus: Header, ViewType, ViewModelType
    layoutService.AddMenu("Home", typeof(HomeView), typeof(HomeViewModel));
    layoutService.AddMenu("Settings", typeof(SettingsView), typeof(SettingsViewModel));
}
```

### 3. Use Layout Control
Place `SideMenuLayout` in your main page (e.g., `MainPage.xaml`).
```xml
<UserControl xmlns:awes="clr-namespace:Awes.UiKit.Control;assembly=Awes.UiKit.Control">
    <awes:SideMenuLayout />
</UserControl>
```

## Navigation

You can navigate between views programmatically and pass parameters.

### Navigate
```csharp
// Navigate to "Settings"
_layoutService.Navigate("Settings");

// Navigate with parameter
await _layoutService.NavigateAsync("Detail", "SomeParameterID");
```

### Receive Parameters
Implement `INavigationAware` in your ViewModel to handle navigation events.
```csharp
using Awes.UiKit.Model;

public class DetailViewModel : ObservableObject, INavigationAware
{
    public Task OnNavigatedToAsync(object? parameter)
    {
        if (parameter is string id)
        {
            // Handle the parameter
            LoadData(id);
        }
        return Task.CompletedTask;
    }
}
```

## Dependencies
- OpenSilver 3.x
- Microsoft.Extensions.DependencyInjection
- CommunityToolkit.Mvvm

## License
MIT

Source & issues: https://github.com/JakobSung/Awes.UiKit
