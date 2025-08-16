# &#x2728; Awes.UiKit.OpenSilver

(OpenSilver ��� UI Kit + ���� ���ø����̼�)

���� ������ ���̾ƿ�(SideMenuLayout), ����(DI), ��Ÿ�� ���� �����ϸ� Simulator / WebAssembly ȯ�濡�� ����˴ϴ�.

> NOTE: ������ UTF-8 ���ڵ��Դϴ�. �̸����� HTML ��ƼƼ�� ǥ���Ͽ�(��: `&#x2728;`) ���ڵ�/��Ʈ ���� �ÿ��� ������ �ʵ��� �߽��ϴ�.

## &#x1F4D6; 1. ����
- OpenSilver XAML UI ������Ʈ ���� �� ���� Kit
- ListBox + Content ���� ��� SideMenu ���̾ƿ� ����
- Microsoft.Extensions.DependencyInjection ��� Ȯ�� (AddAwesUiKit)
- WebAssembly(������) & Simulator ���� ����

## &#x1F6E0; 2. ��� ��� & �����ӿ�ũ
| ��� | �뵵 |
|------|------|
| OpenSilver 3.x | XAML UI ������ (Silverlight ��Ÿ��) |
| .NET Standard 2.0 | ���� ���̺귯�� Ÿ�� |
| .NET 9 / WebAssembly | ������ ȣ���� |
| Blazor WASM Host | OpenSilver WASM ���� ���� |
| Microsoft.Extensions.DependencyInjection | DI �����̳� |

## &#x1F4C1; 3. ������Ʈ ����
| ������Ʈ | ���� |
|----------|------|
| Awes.UiKit.OpenSilver | UI Kit (Layout, Service ���) |
| Awes.UiKit.OpenSilver.Sample | �⺻ ���� (Simulator ���) |
| Awes.UiKit.OpenSilver.Sample.Browser | WebAssembly Host (net9.0) |
| Awes.UiKit.OpenSilver.Sample.Simulator | ����ũ�� Simulator ��Ʈ�� |

## &#x1F4E6; 4. �ٽ� ������ (NuGet)
- OpenSilver / OpenSilver.WebAssembly / OpenSilver.Themes.Modern
- Microsoft.AspNetCore.Components.WebAssembly
- Microsoft.Extensions.DependencyInjection / Abstractions
- CommunityToolkit.Mvvm (�޽�¡/ MVVM Ȯ�� ����)

## &#x1F50C; 5. DI ����
```csharp
var services = new ServiceCollection();
services.AddAwesUiKit();
var provider = services.BuildServiceProvider();
var layout = provider.GetRequiredService<ILayoutManagerService>();
```

## &#x1F680; 6. ����
### Simulator
Visual Studio���� `Awes.UiKit.OpenSilver.Sample.Simulator` ����

### Browser (WebAssembly)
`Awes.UiKit.OpenSilver.Sample.Browser` ���� (F5)

## &#x1F52C; 7. ���� ��ȹ
- LayoutManagerService ��� Ȯ�� (���� �׺���̼�)
- �׺���̼�/����� ��ƿ �߰�
- �׸� / ��ũ��� ����
- �ٱ���(Localization)
- �׽�Ʈ / ���� ViewModel �߰�

## &#x1F4DC; 8. ���̼���
�� ������Ʈ�� MIT ���̼����� �����ϴ�. (LICENSE ���� ����)

## &#x1F91D; 9. �⿩ ���
1. Fork
2. `feature/` �귣ġ ����
3. Ŀ�� & PR ����

�̽� / ���� ������ GitHub Issues Ȱ�� �ٶ��ϴ�.

---
Made for experimentation. &#x2728;