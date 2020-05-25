using MinitureOrderManagementTool.ViewModels;
using ReactiveUI;
using System.Reactive.Disposables;

namespace MinitureOrderManagementTool.Views
{
    /// <summary>
    /// Interaction logic for OrderEditorView.xaml
    /// </summary>
    public partial class OrderEditorView : ReactiveWindow<OrderEditorViewModel>, IClosable
    {
        public OrderEditorView()
        {
            this.InitializeComponent();

            this.WhenActivated(d =>
            {
                this.ViewModel.CommonOrderEditorViewModel = this.commonOrderEditorView.ViewModel;

                this.Bind(this.ViewModel, vm => vm.IsOrderFinished, v => v.isFinishedCheckBox.IsChecked).DisposeWith(d);
                this.Bind(this.ViewModel, vm => vm.OrderTimeSpent, v => v.timeSpentNumericTextBox.Text).DisposeWith(d);

                this.BindCommand(this.ViewModel, vm => vm.UpdateOrderCommand, view => view.updateOrderButton).DisposeWith(d);
                this.BindCommand(this.ViewModel, vm => vm.CancelCommand, view => view.cancelButton).DisposeWith(d);
            });
        }
    }
}
