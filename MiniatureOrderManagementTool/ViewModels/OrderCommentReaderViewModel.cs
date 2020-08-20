using MiniatureOrderManagementTool.Models;
using ReactiveUI;
using System.Reactive;
using System.Windows;

namespace MiniatureOrderManagementTool.ViewModels
{
    public class OrderCommentReaderViewModel : CommonOrderCommentEditorViewModel
    {
        private PartManager partManager;

        public IWindow Window { get; set; }

        private double left;
        public double Left
        {
            get => this.left;
            set
            {
                this.RaiseAndSetIfChanged(ref this.left, value);
                App.Config.OrderCommentReaderWindowDelta = new Point(value - App.Config.OrderEditorWindowDelta.X - App.Config.MainWindowPosition.X,
                                                               App.Config.OrderCommentReaderWindowDelta.Y);
            }
        }

        private double top;
        public double Top
        {
            get => this.top;
            set
            {
                this.RaiseAndSetIfChanged(ref this.top, value);
                App.Config.OrderCommentReaderWindowDelta = new Point(App.Config.OrderEditorWindowDelta.X,
                                                               value - App.Config.OrderEditorWindowDelta.Y - App.Config.MainWindowPosition.Y);
            }
        }

        private double width;
        public double Width
        {
            get => this.width;
            set
            {
                this.RaiseAndSetIfChanged(ref this.width, value);
                App.Config.OrderCommentReaderWindowSize = new Size(value, App.Config.OrderCommentReaderWindowSize.Height);
            }
        }

        private double height;
        public double Height
        {
            get => this.height;
            set
            {
                this.RaiseAndSetIfChanged(ref this.height, value);
                App.Config.OrderCommentReaderWindowSize = new Size(App.Config.OrderCommentReaderWindowSize.Width, value);
            }
        }

        public ReactiveCommand<Unit, Unit> AddCommand { get; }
        public ReactiveCommand<Unit, Unit> CancelCommand { get; }

        public OrderCommentReaderViewModel(PartManager partManager)
        {
            this.partManager = partManager;

            this.Left = App.Config.MainWindowPosition.X + App.Config.OrderEditorWindowDelta.X + App.Config.OrderCommentReaderWindowDelta.X;
            this.Top = App.Config.MainWindowPosition.Y + App.Config.OrderEditorWindowDelta.Y + App.Config.OrderCommentReaderWindowDelta.Y;
            this.Width = App.Config.OrderCommentReaderWindowSize.Width;
            this.Height = App.Config.OrderCommentReaderWindowSize.Height;
            this.CancelCommand = ReactiveCommand.Create(this.Cancel);

            this.AddCommand = ReactiveCommand.Create(this.Add);
            this.CancelCommand = ReactiveCommand.Create(this.Cancel);
        }

        private void Add()
        {
            this.partManager.AddFromOrderComment(this.Comment);
            this.Window?.Close();
        }

        private void Cancel()
        {
            this.Window?.Close();
        }
    }
}
