using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WpfConverterControls
{
    public enum ApplicationStyle
    {
        Default,
        Active,
        Toggled
    }

    public class StateToStyleConverter : IValueConverter
    {
        public Style State1Style { get; set; }
        public Style State2Style { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Boolean booleanState)
            {
                switch (booleanState)
                {
                    case true:
                        return State2Style;
                    default:
                        return State1Style;
                }
            }
            if (value is ApplicationStyle appState)
            {
                switch (appState)
                {
                    case ApplicationStyle.Active:
                        return State2Style;
                    default:
                        return State1Style;
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
