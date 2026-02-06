using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Awes.UiKit.Wpf.Sample
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _greeting;

        public string Greeting
        {
            get => _greeting;
            set
            {
                _greeting = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            Greeting = "Hello from MainViewModel!";
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
