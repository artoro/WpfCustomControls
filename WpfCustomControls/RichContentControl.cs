using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfCustomControls
{
    public class RichContentControl : ContentControl
    {
        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(CustomControl), new PropertyMetadata(new CornerRadius(0))); // Domyślna wartość to 0

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }
    }
}
