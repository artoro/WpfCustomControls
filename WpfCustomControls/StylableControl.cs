using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace WpfCustomControls
{

    public class StylableControl : RichContentControl
    {
        static StylableControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(StylableControl), new FrameworkPropertyMetadata(typeof(StylableControl)));
        }


        public static readonly DependencyProperty StatesProperty = DependencyProperty.Register(nameof(States), typeof(ObservableCollection<ControlState>), typeof(StylableControl));

        public ObservableCollection<ControlState> States
        {
            get => (ObservableCollection<ControlState>)GetValue(StatesProperty);
            set => SetValue(StatesProperty, value);
        }



        public StylableControl()
        {
            States = new ObservableCollection<ControlState>();
            //Loaded += (s, e) => UpdateStyle();
            //Loaded += (s, e) => AttachViewModel();
            //States.CollectionChanged += (s, e) => UpdateStyle();
        }


        private void AttachViewModel()
        {
            if (DataContext is INotifyPropertyChanged npc)
            {
                npc.PropertyChanged += (s, e) =>
                {
                    UpdateStyle();
                };
            }
        }


        private void UpdateStyle()
        {
            if (States == null || !States.Any()) return;

            var dynamicStyle = new Style(typeof(StylableControl), this.Style);

            foreach (var state in States)
            {
                if (string.IsNullOrEmpty(state.Condition) || state.StateStyle?.Setters.Count == 0) continue;
                
                var newBinding = new Binding(state.Condition)
                {
                    RelativeSource = new RelativeSource(RelativeSourceMode.Self),
                    Mode = BindingMode.OneWay
                };

                var trigger = new DataTrigger
                {
                    Binding = newBinding,
                    Value = true
                };

                foreach (SetterBase setter in state.StateStyle.Setters)
                    trigger.Setters.Add(setter);

                dynamicStyle.Triggers.Add(trigger);
            }

            this.Style = dynamicStyle;
        }
    }
}



