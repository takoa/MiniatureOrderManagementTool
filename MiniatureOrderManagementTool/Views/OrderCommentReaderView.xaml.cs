using MiniatureOrderManagementTool.ViewModels;
using ReactiveUI;
using System.Reactive.Disposables;

namespace MiniatureOrderManagementTool.Views
{
    public partial class OrderCommentReaderView : ReactiveWindow<OrderCommentReaderViewModel>, IWindow
    {
        public OrderCommentReaderView()
        {
            InitializeComponent();

            this.WhenActivated(d =>
            {
                this.ViewModel.Window = this;

                this.Bind(this.ViewModel, vm => vm.Comment, v => v.commentTextBox.Text).DisposeWith(d);

                this.BindCommand(this.ViewModel, vm => vm.AddCommand, v => v.addButton).DisposeWith(d);
                this.BindCommand(this.ViewModel, vm => vm.CancelCommand, v => v.cancelButton).DisposeWith(d);
            });
        }
    }
}
