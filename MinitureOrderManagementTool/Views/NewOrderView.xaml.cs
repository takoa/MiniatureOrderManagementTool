using MinitureOrderManagementTool.ViewModels;
using ReactiveUI;
using System.Reactive.Disposables;

namespace MinitureOrderManagementTool.Views
{
    /// <summary>
    /// Interaction logic for NewOrderView.xaml
    /// </summary>
    public partial class NewOrderView : ReactiveWindow<NewOrderViewModel>, IClosable
    {
        public NewOrderView()
        {
            this.InitializeComponent();

            this.WhenActivated(d =>
            {
                this.ViewModel.CommonOrderEditorViewModel = this.commonOrderEditorView.ViewModel;

                this.BindCommand(this.ViewModel, vm => vm.AddOrderCommand, view => view.addOrderButton).DisposeWith(d);
                this.BindCommand(this.ViewModel, vm => vm.CancelCommand, view => view.cancelButton).DisposeWith(d);
            });
        }
    }
}
