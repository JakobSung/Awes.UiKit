# Awes.UiKit.OpenSilver

OpenSilver ��� UI Kit + ���� ���ø����̼� ��뷹���Դϴ�. ���� ������ ���̾ƿ�(SideMenuLayout), ����(DI), ��Ÿ�� ���� �����ϸ� Simulator / WebAssembly ȯ�濡�� ����˴ϴ�.

## ����
- OpenSilver XAML UI ������Ʈ ���� �� ���� Kit
- ListBox + Content ���� ��� SideMenu ���̾ƿ� ����
- Microsoft.Extensions.DependencyInjection ��� Ȯ�� (AddAwesUiKit)
- WebAssembly(������) & Simulator ���� ����

## ��� ��� & �����ӿ�ũ
| ��� | �뵵 |
|------|------|
| OpenSilver 3.x | XAML UI ������ (Silverlight ��Ÿ��) |
| .NET Standard 2.0 | ���� ���̺귯�� Ÿ�� |
| .NET 9 / WebAssembly | ������ ȣ���� |
| Blazor WASM Host | OpenSilver WASM ���� ���� |
| Microsoft.Extensions.DependencyInjection | DI �����̳� |

## ������Ʈ ����
| ������Ʈ | ���� |
|----------|------|
| Awes.UiKit.OpenSilver | UI Kit (Layout, Service ���) |
| Awes.UiKit.OpenSilver.Sample | �⺻ ���� (Simulator ���) |
| Awes.UiKit.OpenSilver.Sample.Browser | WebAssembly Host (net9.0) |
| Awes.UiKit.OpenSilver.Sample.Simulator | ����ũ�� Simulator ��Ʈ�� |

## �ٽ� ������ (NuGet)
- OpenSilver / OpenSilver.WebAssembly / OpenSilver.Themes.Modern
- Microsoft.AspNetCore.Components.WebAssembly
- Microsoft.Extensions.DependencyInjection / Abstractions

## DI ����
```csharp
var services = new ServiceCollection();
services.AddAwesUiKit();
var provider = services.BuildServiceProvider();
```

## ����
### Simulator
Visual Studio���� Awes.UiKit.OpenSilver.Sample.Simulator ����

### Browser (WebAssembly)
Awes.UiKit.OpenSilver.Sample.Browser ���� (F5)

## ���� ��ȹ
- LayoutManagerService Ȯ��
- �׺���̼�/����� ��ƿ �߰�
- �׸� / ��ũ��� ����
- �ٱ���(Localization)

## ���̼���
�� ������Ʈ�� MIT ���̼����� �����ϴ�. (LICENSE ���� ����)

## �⿩
1. Fork
2. feature/�귣ġ ����
3. PR ����

�̽� / ���� ������ GitHub Issues Ȱ�� �ٶ��ϴ�.

---
Made for experimentation.