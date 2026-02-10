using System;
using System.Threading.Tasks;
using Awes.UiKit.Service;
using Awes.UiKit.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;

namespace Awes.UiKit.OpenSilver.Sample.ViewModel
{
    public partial class TestViewModel : ObservableObject, INavigationAware
    {
        private readonly ILayoutManagerService _layoutService;
        private string _message = "Test View";

        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        public TestViewModel()
        {
            _layoutService = AwesUiKit.GetServiceProvider()?.GetService(typeof(ILayoutManagerService)) as ILayoutManagerService 
                ?? throw new InvalidOperationException("LayoutManagerService not found");
        }

        [RelayCommand]
        private async Task NavigateToDashboard()
        {
            // DashBoard 화면으로 네비게이션하며 파라미터 전달
            await _layoutService.NavigateAsync("DashBoard", "Passed From TestView");
        }

        public Task OnNavigatedToAsync(object? parameter)
        {
            if (parameter != null)
            {
                Message = $"Navigated with param: {parameter}";
            }
            return Task.CompletedTask;
        }
    }
}
