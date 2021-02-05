using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SubAccountManagement.App.ViewModels.Interfaces;

namespace SubAccountManagement.App.Pages.ErrorPages
{
    /// <summary>
    /// Interaction logic for ApiErrorPage.xaml
    /// </summary>
    public partial class ApiErrorPage : UserControl, IErrorPage
    {
        public ApiErrorPage()
        {
            InitializeComponent();
            DataContext = this;
        }

        public ApiErrorPage(string errorDetails)
        {
            ErrorDetails = errorDetails;
            InitializeComponent();
            DataContext = this;
        }

        public string ErrorDetails { get; set; }
    }
}
