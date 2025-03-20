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
        public static readonly DependencyProperty StateStyleProperty = DependencyProperty.Register(nameof(StateStyle), typeof(Style), typeof(ControlState));
        
        public Style StateStyle
        {
            get => (Style)GetValue(StateStyleProperty);
            set => SetValue(StateStyleProperty, value);
        }
        

        public static readonly DependencyProperty ConditionProperty = DependencyProperty.Register(nameof(Condition), typeof(string), typeof(ControlState));
        
        public string Condition
        {
            get => (string)GetValue(ConditionProperty);
            set => SetValue(ConditionProperty, value);
        }


        protected override Freezable CreateInstanceCore() => new ControlState();
    }
}
