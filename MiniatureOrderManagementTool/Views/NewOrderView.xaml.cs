using MiniatureOrderManagementTool.ViewModels;
using ReactiveUI;
using System.Reactive.Disposables;
using System.Windows;

namespace MiniatureOrderManagementTool.Views
{
    public partial class NewOrderView : ReactiveWindow<NewOrderViewModel>, IWindow
    {
        public NewOrderView()
        {
            this.InitializeComponent();

            this.WhenActivated(d =>
            {
                this.commonOrderEditorView.ViewModel = this.ViewModel;
                this.ViewModel.ConfirmationBox = new ConfirmationBox(this);
                this.ViewModel.Window = this;

                this.Bind(this.ViewModel, vm => vm.Left, v => v.Left).DisposeWith(d);
                this.Bind(this.ViewModel, vm => vm.Top, v => v.Top).DisposeWith(d);
                this.Bind(this.ViewModel, vm => vm.Width, v => v.Width).DisposeWith(d);
                this.Bind(this.ViewModel, vm => vm.Height, v => v.Height).DisposeWith(d);

                this.BindCommand(this.ViewModel, vm => vm.AddOrderCommand, v => v.addOrderButton).DisposeWith(d);
                this.BindCommand(this.ViewModel, vm => vm.CancelCommand, v => v.cancelButton).DisposeWith(d);

                this.Events().Closing.InvokeCommand(this, x => x.ViewModel.ClosingEventCommand);
            });
        }
    }
}
