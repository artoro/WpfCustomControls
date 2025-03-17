using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace WpfCustomControls
{
    //public class StylableControl : ContentControl
    //{
    //    static StylableControl()
    //    {
    //        DefaultStyleKeyProperty.OverrideMetadata(
    //            typeof(StylableControl),
    //            new FrameworkPropertyMetadata(typeof(StylableControl))
    //        );
    //    }

    //    // CornerRadius
    //    public static readonly DependencyProperty CornerRadiusProperty =
    //        DependencyProperty.Register(
    //            nameof(CornerRadius),
    //            typeof(CornerRadius),
    //            typeof(StylableControl),
    //            new PropertyMetadata(new CornerRadius(0))); // Domyślna wartość to 0

    //    public CornerRadius CornerRadius
    //    {
    //        get => (CornerRadius)GetValue(CornerRadiusProperty);
    //        set => SetValue(CornerRadiusProperty, value);
    //    }
    //}

    public class StylableControl : ContentControl
    {
        //public static readonly DependencyProperty StatesProperty =
        //DependencyProperty.Register(
        //    nameof(States),
        //    typeof(ObservableCollection<ControlState>),
        //    typeof(StylableControl),
        //    new PropertyMetadata(new ObservableCollection<ControlState>())); // Inicjalizacja kolekcji
        public static readonly DependencyProperty StatesProperty =
            DependencyProperty.Register(
                nameof(States),
                typeof(ObservableCollection<ControlState>),
                typeof(StylableControl));

        public StylableControl()
        {
            // Każda instancja otrzymuje swoją własną kolekcję
            States = new ObservableCollection<ControlState>();
            Loaded += (s, e) => UpdateStyle();
            States.CollectionChanged += (s, e) => UpdateStyle();
        }


        public ObservableCollection<ControlState> States
        {
            get => (ObservableCollection<ControlState>)GetValue(StatesProperty);
            set => SetValue(StatesProperty, value);
        }

        static StylableControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(StylableControl),
                new FrameworkPropertyMetadata(typeof(StylableControl)));
        }

        //public StylableControl()
        //{
        //    // Inicjalizacja kolekcji (jeśli nie została ustawiona w XAML)
        //    if (States == null)
        //    {
        //        States = new ObservableCollection<ControlState>();
        //    }

        //    Loaded += (s, e) => UpdateStyle();
        //    States.CollectionChanged += (s, e) => UpdateStyle();
        //}

        private void UpdateStyle()
        {
            if (States == null || !States.Any()) return;

            var dynamicStyle = new Style(typeof(StylableControl), this.Style);

            foreach (var state in States)
            {
                if (!string.IsNullOrEmpty(state.ConditionPropertyName))
                {
                    var newBinding = new Binding(state.ConditionPropertyName)
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
                    {
                        trigger.Setters.Add(setter);
                    }

                    dynamicStyle.Triggers.Add(trigger);
                }
            }

            this.Style = dynamicStyle;
        }


        // CornerRadius
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register(
                nameof(CornerRadius),
                typeof(CornerRadius),
                typeof(StylableControl),
                new PropertyMetadata(new CornerRadius(0))); // Domyślna wartość to 0

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }
    }
}



