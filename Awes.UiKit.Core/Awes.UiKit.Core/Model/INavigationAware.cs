using System.Threading.Tasks;

namespace Awes.UiKit.Model
{
    /// <summary>
    /// 네비게이션 시 파라미터를 전달받기 위한 인터페이스
    /// </summary>
    public interface INavigationAware
    {
        /// <summary>
        /// 해당 화면으로 네비게이션 되었을 때 호출됩니다.
        /// </summary>
        /// <param name="parameter">전달된 파라미터</param>
        /// <returns></returns>
        Task OnNavigatedToAsync(object? parameter);
    }
}
