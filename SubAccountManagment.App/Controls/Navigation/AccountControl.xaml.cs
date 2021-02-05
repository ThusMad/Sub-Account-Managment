using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using GalaSoft.MvvmLight.Command;
using SubAccountManagement.App.Annotations;

namespace SubAccountManagement.App.Controls.Navigation
{
    /// <summary>
    /// Interaction logic for AccountControl.xaml
    /// </summary>
    public partial class AccountControl : UserControl
    {
        private DispatcherTimer timer;
        private DoubleAnimation animation;
        private Storyboard sb;

        private double widthBefore;

        public AccountControl()
        {
            InitializeComponent();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += timer_Tick;

            widthBefore = HeaderWidth;

            animation = new DoubleAnimation();
            animation.Duration = new Duration(TimeSpan.FromMilliseconds(70));

            Storyboard.SetTarget(animation, this);
            Storyboard.SetTargetProperty(animation, new PropertyPath(HeaderWidthProperty));

            sb = new Storyboard();
            sb.Children.Add(animation);

            MouseEnterCommand = new RelayCommand(() => timer.Start());
            MouseLeaveCommand = new RelayCommand(() =>
            {
                timer.Stop();

                animation.From = HeaderWidth;
                animation.To = widthBefore;
                sb.Begin();
            });
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();

            widthBefore = HeaderWidth;

            animation.From = HeaderWidth;
            animation.To = 300;
            sb.Begin();
        }

        public RelayCommand MouseEnterCommand { get; set; }
        public RelayCommand MouseLeaveCommand { get; set; }

        public static readonly DependencyProperty HeaderWidthProperty =
            DependencyProperty.Register(
                "HeaderWidth",
                typeof(double),
                typeof(AccountControl),
                new FrameworkPropertyMetadata(0d));

        public double HeaderWidth
        {
            get => (double)GetValue(HeaderWidthProperty);
            set => SetValue(HeaderWidthProperty, value);
        }

        public static readonly DependencyProperty EmailProperty =
            DependencyProperty.Register(
                "Email",
                typeof(string),
                typeof(AccountControl),
                new FrameworkPropertyMetadata(""));

        public string Email
        {
            get => (string)GetValue(EmailProperty);
            set => SetValue(EmailProperty, value);
        }

        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register(
                "Label",
                typeof(string),
                typeof(AccountControl),
                new FrameworkPropertyMetadata(""));

        public string Label
        {
            get => (string)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        public static readonly DependencyProperty CountProperty =
            DependencyProperty.Register(
                "Count",
                typeof(int),
                typeof(AccountControl),
                new FrameworkPropertyMetadata(0));

        public int Count
        {
            get => (int)GetValue(CountProperty);
            set => SetValue(CountProperty, value);
        }

        public static readonly DependencyProperty SubAccountsProperty =
            DependencyProperty.Register("SubAccounts", 
                typeof(object),
                typeof(AccountControl),
                new UIPropertyMetadata(null));

        public object SubAccounts
        {
            get => GetValue(SubAccountsProperty);
            set => SetValue(SubAccountsProperty, value);
        }
    }
}
