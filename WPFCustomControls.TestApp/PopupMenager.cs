using System;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using System.Windows;

namespace WPFCustomControls.TestApp
{
    public static class PopupMenager
    {
        public static void ShowPopup(Window owner, Point position, string message = "")
        {
            // Tworzymy nowe okno typu Popup
            Popup popup = new Popup
            {
                StaysOpen = false
            };

            // Tworzymy zawartość Popup
            Border popupBorder = new Border
            {
                Background = Brushes.LightYellow,
                Opacity = 0.5,
                Padding = new Thickness(10),
                CornerRadius = new CornerRadius(5)
            };

            TextBlock popupText = new TextBlock
            {
                Text = $"Clicked {message}!",
                HorizontalAlignment=HorizontalAlignment.Center,
                VerticalAlignment=VerticalAlignment.Center,
                FontWeight = FontWeights.Bold,
                FontSize = 12
            };

            popupBorder.Child = popupText;
            popup.Child = popupBorder;

            // Tworzymy okno pomocnicze do wyświetlenia Popup poza głównym oknem
            Window popupWindow = new Window
            {
                WindowStyle = WindowStyle.None,
                AllowsTransparency = true,
                Background = Brushes.Transparent,
                Topmost = true,
                Width = 160,
                Height = 50,
                Content = popupBorder,
                Left = owner.Left + position.X,
                Top = owner.Top + position.Y
            };

            popupWindow.Show();

            // Ustawiamy timer do zamknięcia okna po 1 sekundzie
            DispatcherTimer timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            timer.Tick += (s, e) =>
            {
                popupWindow.Close();
                timer.Stop();
            };
            timer.Start();
        }
    }
}
