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

namespace SubAccountManagement.App.Controls.Wrappers
{
    public partial class IconWrapper : UserControl
    {
        public IconWrapper()
        {
            InitializeComponent();
        }

        public IconWrapper(DrawingGroup drawingGroup)
        {
            InitializeComponent();

            Group = drawingGroup;
        }

        public static readonly DependencyProperty GroupProperty =
            DependencyProperty.RegisterAttached("Group", typeof(DrawingGroup), typeof(IconWrapper),
                new PropertyMetadata(null, GroupPropertyChangedCallback));

        private static void GroupPropertyChangedCallback(DependencyObject dependencyObject,
            DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            ((IconWrapper) dependencyObject).GroupPropertyChanged(
                (DrawingGroup) dependencyPropertyChangedEventArgs.NewValue);
        }

        private void GroupPropertyChanged(DrawingGroup newValue)
        {
            Group = newValue;
            Redraw();
        }

        public DrawingGroup Group
        {
            get => (DrawingGroup) GetValue(GroupProperty);
            set => SetValue(GroupProperty, value);
        }


        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.RegisterAttached("Color", typeof(SolidColorBrush), typeof(IconWrapper),
                new PropertyMetadata(Brushes.White, PropertyChangedCallback));

        private static void PropertyChangedCallback(DependencyObject dependencyObject,
            DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            ((IconWrapper) dependencyObject).ColorPropertyChanged(
                (SolidColorBrush) dependencyPropertyChangedEventArgs.NewValue);
        }

        private void ColorPropertyChanged(SolidColorBrush newValue)
        {
            Color = newValue;
            Redraw();
        }

        public SolidColorBrush Color
        {
            get => (SolidColorBrush) GetValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }


        private void Redraw()
        {
            var groupClone = Group.Clone();

            if (Group != null)
                foreach (var item in groupClone.Children)
                {
                    if ((item as GeometryDrawing).Pen != null)
                        (item as GeometryDrawing).Pen.Brush = Color;
                    else
                        (item as GeometryDrawing).Brush = Color;
                }

            ImageCtrl.Source = new DrawingImage(groupClone);
        }
    }
}
