using MiniatureOrderManagementTool.ViewModels;
using ReactiveUI;
using System.Reactive.Disposables;

namespace MiniatureOrderManagementTool.Views
{
    public partial class NewOrderView : ReactiveWindow<NewOrderViewModel>, IClosable
    {
        public NewOrderView()
        {
            this.InitializeComponent();

            this.WhenActivated(d =>
            {
                this.commonOrderEditorView.ViewModel = this.ViewModel;

                this.Bind(this.ViewModel, vm => vm.Left, v => v.Left).DisposeWith(d);
                this.Bind(this.ViewModel, vm => vm.Top, v => v.Top).DisposeWith(d);
                this.Bind(this.ViewModel, vm => vm.Width, v => v.Width).DisposeWith(d);
                this.Bind(this.ViewModel, vm => vm.Height, v => v.Height).DisposeWith(d);

                this.BindCommand(this.ViewModel, vm => vm.AddOrderCommand, view => view.addOrderButton).DisposeWith(d);
                this.BindCommand(this.ViewModel, vm => vm.CancelCommand, view => view.cancelButton).DisposeWith(d);
            });
        }
    }
}
