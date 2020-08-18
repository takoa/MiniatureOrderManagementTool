using MiniatureOrderManagementTool.ViewModels;
using ReactiveUI;
using System.ComponentModel;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace MiniatureOrderManagementTool.Views
{
    public partial class OrderEditorView : ReactiveWindow<OrderEditorViewModel>, IWindow
    {
        public OrderEditorView()
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
                this.Bind(this.ViewModel, vm => vm.IsOrderFinished, v => v.isFinishedCheckBox.IsChecked).DisposeWith(d);
                this.Bind(this.ViewModel, vm => vm.OrderTimeSpent, v => v.timeSpentNumericTextBox.Text).DisposeWith(d);

                this.BindCommand(this.ViewModel, vm => vm.UpdateOrderCommand, v => v.updateOrderButton).DisposeWith(d);
                this.BindCommand(this.ViewModel, vm => vm.CancelCommand, v => v.cancelButton).DisposeWith(d);

                Observable.FromEventPattern<CancelEventArgs>(this, nameof(this.Closing))
                    .Subscribe(Observer.Create<EventPattern<CancelEventArgs>>(e => this.ViewModel.Cancel(e.EventArgs)))
                    .DisposeWith(d);
            });
        }
    }
}
