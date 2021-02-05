using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using SubAccountManagement.App.Annotations;
using SubAccountManagement.App.Models;
using SubAccountManagement.App.Pages.ErrorPages;

namespace SubAccountManagement.App.ViewModels.ErrorPage
{
    public class ErrorPageInterceptorViewModel : INotifyPropertyChanged
    {
        private object? _errorPage;

        public ErrorPageInterceptorViewModel()
        {
            Messenger.Default.Register<ErrorPageModel?>(
                this,
                this.HandleErrorPageChange);
        }

        public void HandleErrorPageChange(ErrorPageModel? obj)
        {
            if (obj == null)
            {
                return;
            }

            ErrorPage = obj.ErrorPage;
        }

        public object? ErrorPage
        {
            get => _errorPage;
            set
            {
                _errorPage = value;
                OnPropertyChanged(nameof(ErrorPage));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}