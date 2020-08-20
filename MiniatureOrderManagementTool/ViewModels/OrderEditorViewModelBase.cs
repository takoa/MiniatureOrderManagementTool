using MiniatureOrderManagementTool.Models;
using ReactiveUI;
using System.ComponentModel;
using System.Reactive;
using System.Windows;

namespace MiniatureOrderManagementTool.ViewModels
{
    public class OrderEditorViewModelBase : CommonOrderEditorViewModel
    {
        private Config config;

        public IConfirmationBox ConfirmationBox { get; set; }
        public IWindow Window { get; set; }
        public bool ShowsConfirmation { get; set; } = true;

        private double left;
        public double Left
        {
            get => this.left;
            set
            {
                this.RaiseAndSetIfChanged(ref this.left, value);
                this.config.OrderEditorWindowDelta = new Point(value - this.config.MainWindowPosition.X, this.config.OrderEditorWindowDelta.Y);
            }
        }

        private double top;
        public double Top
        {
            get => this.top;
            set
            {
                this.RaiseAndSetIfChanged(ref this.top, value);
                this.config.OrderEditorWindowDelta = new Point(this.config.OrderEditorWindowDelta.X, value - this.config.MainWindowPosition.Y);
            }
        }

        private double width;
        public double Width
        {
            get => this.width;
            set
            {
                this.RaiseAndSetIfChanged(ref this.width, value);
                this.config.OrderEditorWindowSize = new Size(value, this.config.OrderEditorWindowSize.Height);
            }
        }

        private double height;
        public double Height
        {
            get => this.height;
            set
            {
                this.RaiseAndSetIfChanged(ref this.height, value);
                this.config.OrderEditorWindowSize = new Size(this.config.OrderEditorWindowSize.Width, value);
            }
        }

        public ReactiveCommand<Unit, Unit> CancelCommand { get; }
        public ReactiveCommand<CancelEventArgs, Unit> ClosingEventCommand { get; }

        public OrderEditorViewModelBase(Config config)
            : this(config, null)
        {
        }

        public OrderEditorViewModelBase(Config config, Order order)
            : base(order)
        {
            this.config = config;

            this.Left = this.config.MainWindowPosition.X + this.config.OrderEditorWindowDelta.X;
            this.Top = this.config.MainWindowPosition.Y + this.config.OrderEditorWindowDelta.Y;
            this.Width = this.config.OrderEditorWindowSize.Width;
            this.Height = this.config.OrderEditorWindowSize.Height;
            this.CancelCommand = ReactiveCommand.Create(this.Cancel);
            this.ClosingEventCommand = ReactiveCommand.Create<CancelEventArgs>(this.Cancel);
        }

        public void Cancel()
        {
            this.Window?.Close();
        }

        public void Cancel(CancelEventArgs e)
        {
            if (this.ShowsConfirmation && !this.ConfirmationBox.Show("本当に取り消しますか？", "キャンセル"))
            {
                e.Cancel = true;
            }
        }
    }
}
