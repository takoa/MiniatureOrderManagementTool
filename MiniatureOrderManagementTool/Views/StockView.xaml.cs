using MiniatureOrderManagementTool.ViewModels;
using ReactiveUI;
using System.Reactive.Disposables;

namespace MiniatureOrderManagementTool.Views
{
    public partial class StockView : ReactiveUserControl<StockViewModel>
    {
        public StockView()
        {
            this.InitializeComponent();
            this.ViewModel = new StockViewModel();

            this.WhenActivated(d =>
            {
                this.OneWayBind(this.ViewModel, vm => vm.StockItems, view => view.stockGrid.ItemsSource).DisposeWith(d);

                this.Bind(this.ViewModel, vm => vm.SelectedStockItem, v => v.stockGrid.SelectedItem).DisposeWith(d);
                this.Bind(this.ViewModel, vm => vm.Name, v => v.nameTextBox.Text).DisposeWith(d);
                this.Bind(this.ViewModel, vm => vm.Count, v => v.countNumericUpDown.Text).DisposeWith(d);
                this.Bind(this.ViewModel, vm => vm.UnitPrice, v => v.unitPriceNumericTextBox.Text).DisposeWith(d);
                this.Bind(this.ViewModel, vm => vm.MaterialCost, v => v.materialCostNumericTextBox.Text).DisposeWith(d);
                this.Bind(this.ViewModel, vm => vm.TimeSpent, v => v.timeSpentTextNumericUpDown.Text).DisposeWith(d);
                this.Bind(this.ViewModel, vm => vm.TotalStockValue, v => v.totalStockValueTextBlock.Text).DisposeWith(d);

                this.BindCommand(this.ViewModel, vm => vm.AddStockItemCommand, v => v.addStockItemButton).DisposeWith(d);
                this.BindCommand(this.ViewModel, vm => vm.RemoveStockItemCommand, v => v.removeStockItemButton).DisposeWith(d);
            });
        }
    }
}
