using MiniatureOrderManagementTool.ViewModels;
using ReactiveUI;
using System.Reactive.Disposables;

namespace MiniatureOrderManagementTool.Views
{
    public partial class OrderEditorView : ReactiveWindow<OrderEditorViewModel>, IClosable
    {
        public OrderEditorView()
        {
            this.InitializeComponent();

            this.WhenActivated(d =>
            {
                this.commonOrderEditorView.ViewModel = this.ViewModel;

                this.Bind(this.ViewModel, vm => vm.Left, v => v.Left).DisposeWith(d);
                this.Bind(this.ViewModel, vm => vm.Top, v => v.Top).DisposeWith(d);
                this.Bind(this.ViewModel, vm => vm.Width, v => v.Width).DisposeWith(d);
                this.Bind(this.ViewModel, vm => vm.Height, v => v.Height).DisposeWith(d);
                this.Bind(this.ViewModel, vm => vm.IsOrderFinished, v => v.isFinishedCheckBox.IsChecked).DisposeWith(d);
                this.Bind(this.ViewModel, vm => vm.OrderTimeSpent, v => v.timeSpentNumericTextBox.Text).DisposeWith(d);

                this.BindCommand(this.ViewModel, vm => vm.UpdateOrderCommand, view => view.updateOrderButton).DisposeWith(d);
                this.BindCommand(this.ViewModel, vm => vm.CancelCommand, view => view.cancelButton).DisposeWith(d);
            });
        }
    }
}
