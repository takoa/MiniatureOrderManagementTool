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
                this.Bind(this.ViewModel, vm => vm.SelectedStockedPart, v => v.stockDataGrid.SelectedItem).DisposeWith(d);
                this.Bind(this.ViewModel, vm => vm.PartName, v => v.partNameTextBox.Text).DisposeWith(d);
                this.Bind(this.ViewModel, vm => vm.PartUnitPrice, v => v.partUnitPriceNumericTextBox.Text).DisposeWith(d);
                this.Bind(this.ViewModel, vm => vm.PartAmount, v => v.partAmountNumericTextBox.Text, x => x.ToString(), PartManager.GetPartAmountInt).DisposeWith(d);

                this.OneWayBind(this.ViewModel, vm => vm.Parts, v => v.partsDataGrid.ItemsSource).DisposeWith(d);
                this.OneWayBind(this.ViewModel, vm => vm.TotalPartCount, v => v.partCountTextBlock.Text, PartManager.GetTotalPartCountString).DisposeWith(d);
                this.OneWayBind(this.ViewModel, vm => vm.TotalPartValue, v => v.partValueTextBlock.Text, PartManager.GetTotalPartValueString).DisposeWith(d);

                this.OneWayBind(this.ViewModel, vm => vm.StockedParts, v => v.stockDataGrid.ItemsSource).DisposeWith(d);

                this.BindCommand(this.ViewModel, vm => vm.AddPartCommand, v => v.addPartButton).DisposeWith(d);
                this.BindCommand(this.ViewModel, vm => vm.RemovePartCommand, v => v.removePartButton).DisposeWith(d);
                this.BindCommand(this.ViewModel, vm => vm.AddStockedPartCommand, v => v.addStockedPartButton).DisposeWith(d);
                this.BindCommand(this.ViewModel, vm => vm.IncrementPartCountCommand, v => v.incrementPartCountButton).DisposeWith(d);
                this.BindCommand(this.ViewModel, vm => vm.DecrementPartCountCommand, v => v.decrementPartCountButton).DisposeWith(d);
                this.BindCommand(this.ViewModel, vm => vm.OpenOrderCommentReaderCommand, v => v.openReadOrderCommentButton).DisposeWith(d);
            });
        }
    }
}
