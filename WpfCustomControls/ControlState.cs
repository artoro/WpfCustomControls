using System;
using System.Windows.Data;
using System.Windows;

namespace WpfCustomControls
{
    public interface IControlState
    {
        Style StateStyle { get; }
        BindingBase Condition { get; }
    }

    public class ControlState : Freezable
    {
        // Wymagane przez Freezable
        protected override Freezable CreateInstanceCore()
        {
            return new ControlState();
        }

        public static readonly DependencyProperty ConditionPropertyNameProperty =
            DependencyProperty.Register(
                "ConditionPropertyName",
                typeof(string),
                typeof(ControlState));

        public string ConditionPropertyName
        {
            get => (string)GetValue(ConditionPropertyNameProperty);
            set => SetValue(ConditionPropertyNameProperty, value);
        }

        public static readonly DependencyProperty StateStyleProperty =
            DependencyProperty.Register(
                "StateStyle",
                typeof(Style),
                typeof(ControlState));

        public Style StateStyle
        {
            get => (Style)GetValue(StateStyleProperty);
            set => SetValue(StateStyleProperty, value);
        }
    }

}
