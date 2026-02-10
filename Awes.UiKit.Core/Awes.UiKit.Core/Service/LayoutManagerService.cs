using Awes.UiKit.Model;
using System.Collections.ObjectModel;
using System.Windows;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace Awes.UiKit.Service
{
    /// <summary>
    /// 레이아웃 관리를 위한 서비스 클래스
    /// </summary>
    public class LayoutManagerService : ILayoutManagerService, INotifyPropertyChanged
    {
        private ObservableCollection<IMenuItem> _menuItems = new ObservableCollection<IMenuItem>();
        private IMenuItem? _currentMenu;

        /// <summary>
        /// 속성 변경 이벤트
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// 현재 선택된 메뉴
        /// </summary>
        public IMenuItem? CurrentMenu
        {
            get => _currentMenu;
            set
            {
                if (_currentMenu != value)
                {
                    _currentMenu = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// 등록된 메뉴 목록을 가져옵니다.
        /// </summary>
        public ObservableCollection<IMenuItem> GetMenuItems()
        {
            return _menuItems;
        }

        /// <summary>
        /// 새 메뉴를 추가합니다.
        /// </summary>
        public virtual void AddMenu(string header, Type view, Type viewModel)
        {
            FrameworkElement v = global::Awes.UiKit.AwesUiKit.GetServiceProvider()?.GetService(view) as FrameworkElement
                ?? throw new InvalidOperationException("View not resolved");
            var vm = global::Awes.UiKit.AwesUiKit.GetServiceProvider()?.GetService(viewModel)
                ?? throw new InvalidOperationException("ViewModel not resolved");
            v.DataContext = vm;

            MenuItem menu = new MenuItem(header, v);
            _menuItems.Add(menu);
        }

        /// <summary>
        /// 지정된 헤더의 메뉴로 네비게이션합니다. (비동기)
        /// </summary>
        /// <param name="header">메뉴 헤더</param>
        /// <param name="parameter">전달할 파라미터</param>
        public virtual async Task NavigateAsync(string header, object? parameter = null)
        {
            var menu = _menuItems.FirstOrDefault(m => m.Header == header);
            if (menu != null)
            {
                CurrentMenu = menu;

                if (menu.ContentView is FrameworkElement element && element.DataContext is INavigationAware navigationAware)
                {
                    await navigationAware.OnNavigatedToAsync(parameter);
                }
            }
        }

        /// <summary>
        /// 지정된 헤더의 메뉴로 네비게이션합니다. (동기)
        /// </summary>
        /// <param name="header">메뉴 헤더</param>
        public virtual void Navigate(string header)
        {
            _ = NavigateAsync(header);
        }

        /// <summary>
        /// 속성 변경 이벤트를 발생시킵니다.
        /// </summary>
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    /// <summary>
    /// 레이아웃 매니저 서비스 인터페이스
    /// </summary>
    public interface ILayoutManagerService
    {
        /// <summary>
        /// 현재 선택된 메뉴
        /// </summary>
        IMenuItem? CurrentMenu { get; set; }

        /// <summary>
        /// 메뉴 목록을 가져옵니다.
        /// </summary>
        ObservableCollection<IMenuItem> GetMenuItems();

        /// <summary>
        /// 메뉴를 추가합니다.
        /// </summary>
        void AddMenu(string header, Type view, Type viewModel);

        /// <summary>
        /// 특정 메뉴로 네비게이션합니다. (비동기)
        /// </summary>
        Task NavigateAsync(string header, object? parameter = null);

        /// <summary>
        /// 특정 메뉴로 네비게이션합니다. (동기)
        /// </summary>
        void Navigate(string header);
    }
}
