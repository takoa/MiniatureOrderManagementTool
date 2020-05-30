using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace MiniatureOrderManagementTool.Controls
{
    public class NumericUpDown : NumericTextBox
    {
        private CancellationTokenSource upButtonCancellationTokenSource;
        private CancellationTokenSource downButtonCancellationTokenSource;
        private DispatcherTimer upTimer = new DispatcherTimer();
        private DispatcherTimer downTimer = new DispatcherTimer();

        public decimal Increment
        {
            get { return (decimal)this.GetValue(IncrementProperty); }
            set { this.SetValue(IncrementProperty, value); }
        }

        public static readonly DependencyProperty IncrementProperty =
            DependencyProperty.Register("Increment", typeof(decimal), typeof(NumericUpDown), new PropertyMetadata(1m, OnIncrementChanged));

        public int IncrementInterval
        {
            get { return (int)this.GetValue(IncrementIntervalProperty); }
            set { this.SetValue(IncrementIntervalProperty, value); }
        }

        public static readonly DependencyProperty IncrementIntervalProperty =
            DependencyProperty.Register("IncrementInterval", typeof(int), typeof(NumericUpDown), new PropertyMetadata(50, OnIncrementIntervalChanged), ValidatesIncrementInterval);

        public event RoutedEventHandler UpButtonClicked
        {
            add => base.AddHandler(UpButtonClickedEvent, value);
            remove => base.RemoveHandler(UpButtonClickedEvent, value);
        }

        public static readonly RoutedEvent UpButtonClickedEvent =
            EventManager.RegisterRoutedEvent("UpButtonClicked", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(NumericUpDown));

        public event RoutedEventHandler DownButtonClicked
        {
            add => base.AddHandler(DownButtonClickedEvent, value);
            remove => base.RemoveHandler(DownButtonClickedEvent, value);
        }

        public static readonly RoutedEvent DownButtonClickedEvent =
            EventManager.RegisterRoutedEvent("DownButtonClicked", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(NumericUpDown));

        static NumericUpDown()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NumericUpDown), new FrameworkPropertyMetadata(typeof(NumericUpDown)));
        }

        public NumericUpDown()
        {
            this.upTimer.Tick += this.IncrementOnce;
            this.downTimer.Tick += this.DecrementOnce;
        }

        public override void OnApplyTemplate()
        {
            if (this.GetTemplateChild("PART_UpButton") is Button upButton)
            {
                upButton.Click += this.UpButton_Clicked;
                upButton.PreviewMouseLeftButtonDown += this.UpButton_PreviewMouseLeftButtonDownAsync;
                upButton.PreviewMouseLeftButtonUp += this.UpButton_PreviewMouseLeftButtonUp;
            }

            if (this.GetTemplateChild("PART_DownButton") is Button downButton)
            {
                downButton.Click += this.DownButton_Clicked;
                downButton.PreviewMouseLeftButtonDown += this.DownButton_PreviewMouseLeftButtonDownAsync;
                downButton.PreviewMouseLeftButtonUp += this.DownButton_PreviewMouseLeftButtonUp;
            }

            base.OnApplyTemplate();
        }

        protected virtual void OnIncrementChanged(DependencyPropertyChangedEventArgs e)
        {
        }

        protected virtual void OnIncrementIntervalChanged(DependencyPropertyChangedEventArgs e)
        {
        }

        protected virtual void OnUpButtonClicked(RoutedEventArgs e)
        {
            this.RaiseEvent(e);
        }

        protected virtual void OnDownButtonClicked(RoutedEventArgs e)
        {
            this.RaiseEvent(e);
        }

        private void UpButton_Clicked(object sender, RoutedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(UpButtonClickedEvent);

            this.OnUpButtonClicked(args);

            if (!args.Handled)
            {
                this.IncrementOnce(sender, e);
            }
        }

        private void DownButton_Clicked(object sender, RoutedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(DownButtonClickedEvent);

            this.OnDownButtonClicked(args);

            if (!args.Handled)
            {
                this.DecrementOnce(sender, e);
            }
        }

        private async void UpButton_PreviewMouseLeftButtonDownAsync(object sender, MouseButtonEventArgs e)
        {
            this.upButtonCancellationTokenSource = new CancellationTokenSource();

            try
            {
                await Task.Delay(1000, this.upButtonCancellationTokenSource.Token);

                this.upTimer.Interval = new TimeSpan(0, 0, 0, 0, this.IncrementInterval);
                this.upTimer.Start();
            }
            catch (OperationCanceledException)
            {
            }
        }

        private void UpButton_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.upButtonCancellationTokenSource?.Cancel();
            this.upTimer.Stop();
        }

        private async void DownButton_PreviewMouseLeftButtonDownAsync(object sender, MouseButtonEventArgs e)
        {
            this.downButtonCancellationTokenSource = new CancellationTokenSource();

            try
            {
                await Task.Delay(1000, this.downButtonCancellationTokenSource.Token);

                this.downTimer.Interval = new TimeSpan(0, 0, 0, 0, this.IncrementInterval);
                this.downTimer.Start();
            }
            catch (OperationCanceledException)
            {
            }
        }

        private void DownButton_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.downButtonCancellationTokenSource?.Cancel();
            this.downTimer.Stop();
        }

        private static void OnIncrementChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is NumericUpDown nud)
            {
                nud.OnIncrementChanged(e);
            }
        }

        private static void OnIncrementIntervalChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is NumericUpDown nud)
            {
                nud.OnIncrementIntervalChanged(e);
            }
        }

        private static bool ValidatesIncrementInterval(object value)
        {
            if (value is int i)
            {
                if (0 <= i)
                {
                    return true;
                }
            }

            return false;
        }

        private void DecrementOnce(object sender, EventArgs e)
        {
            if (decimal.TryParse(this.Text, out var d))
            {
                this.Text = (d - this.Increment).ToString();
            }
        }

        private void IncrementOnce(object sender, EventArgs e)
        {
            if (decimal.TryParse(this.Text, out var d))
            {
                this.Text = (d + this.Increment).ToString();
            }
        }
    }
}
