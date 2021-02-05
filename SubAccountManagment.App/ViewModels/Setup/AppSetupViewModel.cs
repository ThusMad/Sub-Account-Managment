using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using SubAccountManagement.App.Annotations;
using SubAccountManagement.App.Models;
using SubAccountManagement.App.Pages.ErrorPages;
using SubAccountManagement.Core.Client;

namespace SubAccountManagement.App.ViewModels.Setup
{
    public class AppSetupViewModel : INotifyPropertyChanged
    {
        private Visibility _loaderVisibility = Visibility.Visible;
        private Dispatcher _currentDispatcher;
        public AppSetupViewModel()
        {
            CheckConnectivity();
            _currentDispatcher = Dispatcher.CurrentDispatcher;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public Visibility LoaderVisibility
        {
            get => _loaderVisibility;
            set
            {
                _loaderVisibility = value;
                OnPropertyChanged(nameof(LoaderVisibility));
            }
        }

        private void CheckConnectivity()
        {
            Task.Run(async () =>
            {
                await Task.Delay(2000);
                var result = await SubAccountWorker.Instance.PingBinance(10, CancellationToken.None);

                LoaderVisibility = Visibility.Hidden;

                if (!result)
                {
                    _currentDispatcher.Invoke(() =>
                        Messenger.Default.Send<ErrorPageModel?>(new ErrorPageModel(new ApiErrorPage("API doesn't respond. Check your internet connection or BINANCE status.")))
                    );
                }
            });
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}