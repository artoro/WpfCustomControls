using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPFCustomControls.TestApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Point mousePosition = Mouse.GetPosition(this);
            PopupMenager.ShowPopup(this, mousePosition, (sender as FrameworkElement).Name);
        }
    }
}
