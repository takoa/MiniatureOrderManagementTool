using MiniatureOrderManagementTool.ViewModels;
using ReactiveUI;
using System.Reactive.Disposables;

namespace MiniatureOrderManagementTool.Views
{
    public partial class OrderCommentReaderView : ReactiveWindow<OrderCommentReaderViewModel>, IWindow
    {
        public OrderCommentReaderView()
        {
            this.InitializeComponent();

            this.WhenActivated(d =>
            {
                this.ViewModel.Window = this;
                this.orderCommentEditor.ViewModel = this.ViewModel;

                this.Bind(this.ViewModel, vm => vm.Left, v => v.Left).DisposeWith(d);
                this.Bind(this.ViewModel, vm => vm.Top, v => v.Top).DisposeWith(d);
                this.Bind(this.ViewModel, vm => vm.Width, v => v.Width).DisposeWith(d);
                this.Bind(this.ViewModel, vm => vm.Height, v => v.Height).DisposeWith(d);

                this.BindCommand(this.ViewModel, vm => vm.AddCommand, v => v.addButton).DisposeWith(d);
                this.BindCommand(this.ViewModel, vm => vm.CancelCommand, v => v.cancelButton).DisposeWith(d);
            });
        }
    }
}
