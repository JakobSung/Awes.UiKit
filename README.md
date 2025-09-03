# ✨ Awes.UiKit.OpenSilver


[![NuGet Version](https://img.shields.io/nuget/v/Awes.UiKit.OpenSilver.svg)](https://www.nuget.org/packages/Awes.UiKit.OpenSilver/)
[![Build Status](https://github.com/JakobSung/Awes.UiKit/actions/workflows/nuget-publish.yml/badge.svg)](https://github.com/JakobSung/Awes.UiKit/actions/workflows/nuget-publish.yml)

OpenSilver 기반 UI Kit + 샘플 애플리케이션

재사용 가능한 레이아웃(SideMenuLayout) 및 Control, 서비스(DI), 스타일 등을 포함하며 OpenSilver WebAssembly 환경에서 실행됩니다.
https://opensilver.net/

## 📖  개요
- OpenSilver XAML UI 컴포넌트 실험 및 공용 Kit
- SideMenu 레이아웃 제공
- Microsoft.Extensions.DependencyInjection 기반 확장

## 🛠️  사용 기술 & 프레임워크
| 기술 | 용도 |
|------|------|
| OpenSilver 3.x | XAML UI 렌더링 (Silverlight 스타일) |
| .NET Standard 2.0 | 공용 라이브러리 타겟 |
| .NET 9 / WebAssembly | 브라우저 호스팅 |
| Blazor WASM Host | OpenSilver WASM 구동 래퍼 |
| Microsoft.Extensions.DependencyInjection | DI 컨테이너 |

## 📂  프로젝트 구조
| 프로젝트 | 설명 |
|----------|------|
| Awes.UiKit.OpenSilver | UI Kit (Layout, Service 등록) |
| Awes.UiKit.OpenSilver.Sample | 기본 샘플 (Simulator 대상) |
| Awes.UiKit.OpenSilver.Sample.Browser | WebAssembly Host (net9.0) |

## 📦 핵심 의존성 (NuGet)
- OpenSilver / OpenSilver.WebAssembly / OpenSilver.Themes.Modern
- Microsoft.AspNetCore.Components.WebAssembly
- Microsoft.Extensions.DependencyInjection / Abstractions
- CommunityToolkit.Mvvm (메시징)

## 🔌 예시

### net9 (Blazor WebAssembly + OpenSilver)
- net9에서는 전용 빌더(AwesUiKitWasmHostBuilder/AwesUiKitBuilder)로 부트스트랩합니다.
- 화면(View)·뷰모델 등록은 앱(Sample) 프로젝트에서 수행하세요.

```csharp
using Awes.UiKit.OpenSilver.Builder;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    public static async Task Main(string[] args)
    {
        // 기본 WASM 호스트 + 루트 컴포넌트 등록
        var kit = AwesUiKitWasmHostBuilder.CreateHost<App>(args);

        // 앱 전용 서비스(View / ViewModel 등) 등록
        kit.ConfigureServices(services =>
        {
            services.AddScoped<DashBoardView>();
            services.AddScoped<TestContentView>();
            services.AddScoped<TestViewModel>();
        });

        // host.Build() + 전역 ServiceProvider 등록까지 수행
        var host = kit.Build();
        await host.RunAsync();
    }
}
```

전역 ServiceProvider를 통해 서비스 사용 예시:
```csharp
using Awes.UiKit.OpenSilver;
using Microsoft.Extensions.DependencyInjection;

var sp = AwesUiKit.GetServiceProvider();
var layout = sp.GetRequiredService<ILayoutManagerService>();
layout.AddMenu("DashBoard", typeof(DashBoardView), typeof(TestViewModel));
layout.AddMenu("Test", typeof(TestContentView), typeof(TestViewModel));
```

### netstandard2.0
```csharp
using Awes.UiKit.OpenSilver.Service;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
// UI Kit 필수 서비스 등록
services.AddSingleton<ILayoutManagerService, LayoutManagerService>();

// 앱 전용 서비스 등록
services.AddScoped<DashBoardView>();
services.AddScoped<TestContentView>();
services.AddScoped<TestViewModel>();

var provider = services.BuildServiceProvider();
// var layout = provider.GetRequiredService<ILayoutManagerService>();
```

## 🔭 향후 계획
- LayoutManagerService 기능 확장

## 📜 라이선스
이 프로젝트는 MIT 라이선스를 따릅니다. (LICENSE 파일 참조)

## 🤝 기여 방법
1. Fork
2. `feature/` 브랜치 생성
3. 커밋 & PR 생성

이슈 / 개선 제안은 GitHub Issues 활용 바랍니다.

---
Made for experimentation. ✨
