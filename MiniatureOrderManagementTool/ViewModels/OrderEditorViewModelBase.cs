using MiniatureOrderManagementTool.Models;
using ReactiveUI;
using System.ComponentModel;
using System.Reactive;
using System.Windows;

namespace MiniatureOrderManagementTool.ViewModels
{
    public class OrderEditorViewModelBase : CommonOrderEditorViewModel
    {
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
                App.Config.OrderEditorWindowDelta = new Point(value - App.Config.MainWindowPosition.X, App.Config.OrderEditorWindowDelta.Y);
            }
        }

        private double top;
        public double Top
        {
            get => this.top;
            set
            {
                this.RaiseAndSetIfChanged(ref this.top, value);
                App.Config.OrderEditorWindowDelta = new Point(App.Config.OrderEditorWindowDelta.X, value - App.Config.MainWindowPosition.Y);
            }
        }

        private double width;
        public double Width
        {
            get => this.width;
            set
            {
                this.RaiseAndSetIfChanged(ref this.width, value);
                App.Config.OrderEditorWindowSize = new Size(value, App.Config.OrderEditorWindowSize.Height);
            }
        }

        private double height;
        public double Height
        {
            get => this.height;
            set
            {
                this.RaiseAndSetIfChanged(ref this.height, value);
                App.Config.OrderEditorWindowSize = new Size(App.Config.OrderEditorWindowSize.Width, value);
            }
        }

        public ReactiveCommand<Unit, Unit> CancelCommand { get; }
        public ReactiveCommand<CancelEventArgs, Unit> ClosingEventCommand { get; }

        public OrderEditorViewModelBase()
            : this(null)
        {
        }

        public OrderEditorViewModelBase(Order order)
            : base(order)
        {
            this.Left = App.Config.MainWindowPosition.X + App.Config.OrderEditorWindowDelta.X;
            this.Top = App.Config.MainWindowPosition.Y + App.Config.OrderEditorWindowDelta.Y;
            this.Width = App.Config.OrderEditorWindowSize.Width;
            this.Height = App.Config.OrderEditorWindowSize.Height;
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
