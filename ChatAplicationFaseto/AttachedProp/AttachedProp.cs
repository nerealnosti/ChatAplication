
using System.Windows;
using System.Windows.Controls;

namespace ChatAplicationFaseto
{
    class AttachedPropOne
    {



        public static bool GetHasText(DependencyObject obj)
        {
            return (bool)obj.GetValue(HasTextProperty);
        }

        public static void SetHasText(DependencyObject obj, bool value)
        {
            obj.SetValue(HasTextProperty, value);
        }

        // Using a DependencyProperty as the backing store for HasText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HasTextProperty =
            DependencyProperty.RegisterAttached("HasText", typeof(bool), typeof(AttachedPropOne), new PropertyMetadata(false));




        public static bool GetMonitor(DependencyObject obj)
        {
            return (bool)obj.GetValue(MonitorProperty);
        }

        public static void SetMonitor(DependencyObject obj, bool value)
        {
            obj.SetValue(MonitorProperty, value);
        }

        // Using a DependencyProperty as the backing store for Monitor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MonitorProperty =
            DependencyProperty.RegisterAttached("Monitor", typeof(bool), typeof(AttachedPropOne), new PropertyMetadata(false,OnChangeMonitor));

        private static void OnChangeMonitor(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var dp = d as PasswordBox;

            if (dp == null) return;

            if ((bool)e.NewValue)
            {
                SetHasText(d, dp.SecurePassword.Length > 0);
                dp.PasswordChanged += Dp_PasswordChanged;
            }

        }

        private static void Dp_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var b = sender as PasswordBox;

            SetHasText(b, b.SecurePassword.Length > 0);
            var s = GetHasText(b);


        }
    }
}
