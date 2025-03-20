using System;
using System.Windows;
using System.Windows.Input;

namespace WPFCustomControls.TestApp
{
    public class MainWindowViewModel : BaseViewModel
    {
        public RelayCommand<object> ClickButtonCommand { get; }
        public RelayCommand ToggleButtonCommand { get; }


        public bool IsToggled
        {
            get => _isToggled;
            set => Set(ref _isToggled, value);
        }
        private bool _isToggled = true;


        public MainWindowViewModel()
        {
            ToggleButtonCommand = new RelayCommand(_ =>  IsToggled = !IsToggled);
            ClickButtonCommand = new RelayCommand<object>(ShowPopup);
        }

        private void ShowPopup(object element)
        {
            if (element is FrameworkElement fe)
            {
                Point mousePosition = fe.PointToScreen(Mouse.GetPosition(fe));
                PopupMenager.ShowPopup(mousePosition, fe.Name);
            }
        }
    }
}
