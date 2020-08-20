using MiniatureOrderManagementTool.Models;
using ReactiveUI;
using System.Reactive;
using System.Windows;

namespace MiniatureOrderManagementTool.ViewModels
{
    public class OrderCommentReaderViewModel : CommonOrderCommentEditorViewModel
    {
        private Config config;
        private PartManager partManager;

        public IWindow Window { get; set; }

        private double left;
        public double Left
        {
            get => this.left;
            set
            {
                this.RaiseAndSetIfChanged(ref this.left, value);
                this.config.OrderCommentReaderWindowDelta = new Point(value - this.config.OrderEditorWindowDelta.X - this.config.MainWindowPosition.X,
                                                               this.config.OrderCommentReaderWindowDelta.Y);
            }
        }

        private double top;
        public double Top
        {
            get => this.top;
            set
            {
                this.RaiseAndSetIfChanged(ref this.top, value);
                this.config.OrderCommentReaderWindowDelta = new Point(this.config.OrderEditorWindowDelta.X,
                                                               value - this.config.OrderEditorWindowDelta.Y - this.config.MainWindowPosition.Y);
            }
        }

        private double width;
        public double Width
        {
            get => this.width;
            set
            {
                this.RaiseAndSetIfChanged(ref this.width, value);
                this.config.OrderCommentReaderWindowSize = new Size(value, this.config.OrderCommentReaderWindowSize.Height);
            }
        }

        private double height;
        public double Height
        {
            get => this.height;
            set
            {
                this.RaiseAndSetIfChanged(ref this.height, value);
                this.config.OrderCommentReaderWindowSize = new Size(this.config.OrderCommentReaderWindowSize.Width, value);
            }
        }

        public ReactiveCommand<Unit, Unit> AddCommand { get; }
        public ReactiveCommand<Unit, Unit> CancelCommand { get; }

        public OrderCommentReaderViewModel(Config config, PartManager partManager)
        {
            this.config = config;
            this.partManager = partManager;

            this.Left = this.config.MainWindowPosition.X + this.config.OrderEditorWindowDelta.X + this.config.OrderCommentReaderWindowDelta.X;
            this.Top = this.config.MainWindowPosition.Y + this.config.OrderEditorWindowDelta.Y + this.config.OrderCommentReaderWindowDelta.Y;
            this.Width = this.config.OrderCommentReaderWindowSize.Width;
            this.Height = this.config.OrderCommentReaderWindowSize.Height;
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
