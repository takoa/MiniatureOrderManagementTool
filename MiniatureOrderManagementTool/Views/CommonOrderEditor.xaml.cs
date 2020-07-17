using MiniatureOrderManagementTool.Models;
using MiniatureOrderManagementTool.ViewModels;
using ReactiveUI;
using System.Reactive.Disposables;

namespace MiniatureOrderManagementTool.Views
{
    public partial class CommonOrderEditorView : ReactiveUserControl<CommonOrderEditorViewModel>
    {
        public CommonOrderEditorView()
        {
            this.InitializeComponent();

            this.WhenActivated(d =>
            {
                this.Bind(this.ViewModel, vm => vm.Name, v => v.orderNameTextBox.Text).DisposeWith(d);
                this.Bind(this.ViewModel, vm => vm.Price, v => v.priceNumericTextBox.Text).DisposeWith(d);
                this.Bind(this.ViewModel, vm => vm.Discount, v => v.discountNumericTextBox.Text).DisposeWith(d);
                this.Bind(this.ViewModel, vm => vm.Customer, v => v.customerTextBox.Text).DisposeWith(d);
                this.Bind(this.ViewModel, vm => vm.Deadline, v => v.deadlineDatePicker.SelectedDate).DisposeWith(d);
                this.Bind(this.ViewModel, vm => vm.Description, v => v.descriptionTextBox.Text).DisposeWith(d);
                this.Bind(this.ViewModel, vm => vm.SelectedPart, v => v.partsDataGrid.SelectedItem).DisposeWith(d);
                this.Bind(this.ViewModel, vm => vm.PartName, v => v.partNameTextBox.Text).DisposeWith(d);
                this.Bind(this.ViewModel, vm => vm.PartAmount, v => v.partAmountNumericTextBox.Text, x => x.ToString(), PartManager.GetPartAmountInt).DisposeWith(d);

                this.OneWayBind(this.ViewModel, vm => vm.ObservableParts, v => v.partsDataGrid.ItemsSource).DisposeWith(d);
                this.OneWayBind(this.ViewModel, vm => vm.TotalPartCount, v => v.partCountTextBlock.Text).DisposeWith(d);

                this.BindCommand(this.ViewModel, vm => vm.AddPartCommand, view => view.addPartButton).DisposeWith(d);
                this.BindCommand(this.ViewModel, vm => vm.RemovePartCommand, view => view.removePartButton).DisposeWith(d);
            });
        }
    }
}
