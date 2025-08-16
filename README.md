# &#x2728; Awes.UiKit.OpenSilver

(OpenSilver 기반 UI Kit + 샘플 애플리케이션)

재사용 가능한 레이아웃(SideMenuLayout), 서비스(DI), 스타일 등을 포함하며 Simulator / WebAssembly 환경에서 실행됩니다.


## &#x1F4D6;  개요
- OpenSilver XAML UI 컴포넌트 실험 및 공용 Kit
- ListBox + Content 패턴 기반 SideMenu 레이아웃 제공
- Microsoft.Extensions.DependencyInjection 기반 확장 (AddAwesUiKit)
- WebAssembly(브라우저) & Simulator 실행 지원

## &#x1F6E0;  사용 기술 & 프레임워크
| 기술 | 용도 |
|------|------|
| OpenSilver 3.x | XAML UI 렌더링 (Silverlight 스타일) |
| .NET Standard 2.0 | 공용 라이브러리 타겟 |
| .NET 9 / WebAssembly | 브라우저 호스팅 |
| Blazor WASM Host | OpenSilver WASM 구동 래퍼 |
| Microsoft.Extensions.DependencyInjection | DI 컨테이너 |

## &#x1F4C1;  프로젝트 구조
| 프로젝트 | 설명 |
|----------|------|
| Awes.UiKit.OpenSilver | UI Kit (Layout, Service 등록) |
| Awes.UiKit.OpenSilver.Sample | 기본 샘플 (Simulator 대상) |
| Awes.UiKit.OpenSilver.Sample.Browser | WebAssembly Host (net9.0) |
| Awes.UiKit.OpenSilver.Sample.Simulator | 데스크톱 Simulator 엔트리 |

## &#x1F4E6; 4. 핵심 의존성 (NuGet)
- OpenSilver / OpenSilver.WebAssembly / OpenSilver.Themes.Modern
- Microsoft.AspNetCore.Components.WebAssembly
- Microsoft.Extensions.DependencyInjection / Abstractions
- CommunityToolkit.Mvvm (메시징/ MVVM 확장 가능)

## &#x1F50C;  DI 예시
```csharp
var services = new ServiceCollection();
services.AddAwesUiKit();
var provider = services.BuildServiceProvider();
var layout = provider.GetRequiredService<ILayoutManagerService>();
```



### Browser (WebAssembly)
`Awes.UiKit.OpenSilver.Sample.Browser` 실행 (F5)

## &#x1F52C;  향후 계획
- LayoutManagerService 기능 확장 (동적 네비게이션)
- 네비게이션/라우팅 유틸 추가
- 테마 / 다크모드 지원
- 다국어(Localization)
- 테스트 / 샘플 ViewModel 추가

## &#x1F4DC;  라이선스
이 프로젝트는 MIT 라이선스를 따릅니다. (LICENSE 파일 참조)

## &#x1F91D;  기여 방법
1. Fork
2. `feature/` 브랜치 생성
3. 커밋 & PR 생성

이슈 / 개선 제안은 GitHub Issues 활용 바랍니다.

---
Made for experimentation. &#x2728;
