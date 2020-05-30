using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MiniatureOrderManagementTool.Controls
{
    public class NumericTextBox : TextBox
    {
        private static readonly KeyBinding pasteKeyBinding1 = new KeyBinding(ApplicationCommands.NotACommand, Key.V, ModifierKeys.Control);
        private static readonly KeyBinding pasteKeyBinding2 = new KeyBinding(ApplicationCommands.NotACommand, Key.Insert, ModifierKeys.Shift);

        private string oldText = string.Empty;

        public bool AllowRightClick
        {
            get => (bool)this.GetValue(AllowRightClickProperty);
            set => this.SetValue(AllowRightClickProperty, value);
        }

        public static readonly DependencyProperty AllowRightClickProperty =
            DependencyProperty.Register("AllowRightClick", typeof(bool), typeof(NumericTextBox), new PropertyMetadata(true, OnAllowRightClickChanged));

        public bool AllowPaste
        {
            get { return (bool)this.GetValue(AllowPasteProperty); }
            set { this.SetValue(AllowPasteProperty, value); }
        }

        public static readonly DependencyProperty AllowPasteProperty =
            DependencyProperty.Register("AllowPaste", typeof(bool), typeof(NumericTextBox), new PropertyMetadata(true, OnAllowPasteChanged));

        public decimal Maximum
        {
            get { return (decimal)this.GetValue(MaximumProperty); }
            set { this.SetValue(MaximumProperty, value); }
        }

        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register("Maximum", typeof(decimal), typeof(NumericTextBox), new PropertyMetadata((decimal)int.MaxValue, OnMaximumChanged));

        public decimal Minimum
        {
            get { return (decimal)this.GetValue(MinimumProperty); }
            set { this.SetValue(MinimumProperty, value); }
        }

        public static readonly DependencyProperty MinimumProperty =
            DependencyProperty.Register("Minimum", typeof(decimal), typeof(NumericTextBox), new PropertyMetadata((decimal)int.MinValue, OnMinimumChanged));

        static NumericTextBox()
        {
            InputMethod.IsInputMethodEnabledProperty.OverrideMetadata(typeof(NumericTextBox), new FrameworkPropertyMetadata(false));
        }

        public NumericTextBox()
        {
        }

        protected override void OnPreviewMouseRightButtonUp(MouseButtonEventArgs e)
        {
            if (!this.AllowRightClick)
            {
                e.Handled = true;
            }
        }

        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            if (decimal.TryParse(this.Text, out var d))
            {
                if (this.Minimum <= d && d <= this.Maximum)
                {
                    this.oldText = this.Text;
                }
                else
                {
                    this.Text = this.oldText;
                }
            }
            else
            {
                this.Text = this.oldText;
            }

            base.OnTextChanged(e);
        }

        protected virtual void OnAllowRightClickChanged(DependencyPropertyChangedEventArgs e)
        {
        }

        protected virtual void OnAllowPasteChanged(DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue)
            {
                this.InputBindings.Remove(pasteKeyBinding1);
                this.InputBindings.Remove(pasteKeyBinding2);
            }
            else
            {
                this.InputBindings.Add(pasteKeyBinding1);
                this.InputBindings.Add(pasteKeyBinding2);
            }
        }

        protected virtual void OnMaximumChanged(DependencyPropertyChangedEventArgs e)
        {
        }

        protected virtual void OnMinimumChanged(DependencyPropertyChangedEventArgs e)
        {
        }

        private static void OnAllowRightClickChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is NumericTextBox ntb)
            {
                ntb.OnAllowRightClickChanged(e);
            }
        }

        private static void OnAllowPasteChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is NumericTextBox ntb)
            {
                ntb.OnAllowPasteChanged(e);
            }
        }

        private static void OnMaximumChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is NumericTextBox ntb)
            {
                ntb.OnMaximumChanged(e);
            }
        }

        private static void OnMinimumChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is NumericTextBox ntb)
            {
                ntb.OnMinimumChanged(e);
            }
        }
    }
}
