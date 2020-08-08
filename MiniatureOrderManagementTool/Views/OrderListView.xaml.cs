using MiniatureOrderManagementTool.Models;
using MiniatureOrderManagementTool.ViewModels;
using ReactiveUI;
using System.Reactive.Disposables;

namespace MiniatureOrderManagementTool.Views
{
    public partial class OrderListView : ReactiveUserControl<OrderListViewModel>
    {
        public OrderListView()
        {
            this.InitializeComponent();
            this.ViewModel = new OrderListViewModel();

            this.WhenActivated(d =>
            {
                this.OneWayBind(this.ViewModel, vm => vm.Orders, v => v.ordersListView.ItemsSource).DisposeWith(d);
                this.Bind(this.ViewModel, vm => vm.SelectedOrder, v => v.ordersListView.SelectedItem).DisposeWith(d);

                this.OneWayBind(this.ViewModel, vm => vm.SelectedOrder.IsFinished, v => v.isFinishedTextBlock.Text, OrderManager.GetIsFinishedString).DisposeWith(d);
                this.OneWayBind(this.ViewModel, vm => vm.SelectedOrder.TimeSpent, v => v.timeSpantTextBlock.Text, OrderManager.GetTimeSpentString).DisposeWith(d);
                this.OneWayBind(this.ViewModel, vm => vm.SelectedOrder.Name, v => v.orderNameTextBlock.Text).DisposeWith(d);
                this.OneWayBind(this.ViewModel, vm => vm.SelectedOrder.Customer, v => v.customerTextBlock.Text).DisposeWith(d);
                this.OneWayBind(this.ViewModel, vm => vm.SelectedOrder, v => v.priceTextBlock.Text, OrderManager.GetDiscountedPrice).DisposeWith(d);
                this.OneWayBind(this.ViewModel, vm => vm.SelectedOrder.Discount, v => v.discountTextBlock.Text).DisposeWith(d);
                this.OneWayBind(this.ViewModel, vm => vm.SelectedOrder.Price, v => v.originalPriceTextBlock.Text).DisposeWith(d);
                this.OneWayBind(this.ViewModel, vm => vm.SelectedOrder.Deadline, v => v.deadlineDateTextBlock.Text, OrderManager.GetDeadlineString).DisposeWith(d);
                this.OneWayBind(this.ViewModel, vm => vm.SelectedOrder.CreatedAt, v => v.createdAtTextBlock.Text, OrderManager.GetDeadlineString).DisposeWith(d);
                this.OneWayBind(this.ViewModel, vm => vm.SelectedOrder.ModifiedAt, v => v.modifiedAtTextBlock.Text, OrderManager.GetDeadlineString).DisposeWith(d);
                this.OneWayBind(this.ViewModel, vm => vm.SelectedOrder.Description, v => v.descriptionTextBlock.Text).DisposeWith(d);
                this.OneWayBind(this.ViewModel, vm => vm.SelectedOrder.Parts, v => v.partsDataGrid.ItemsSource).DisposeWith(d);

                this.BindCommand(this.ViewModel, vm => vm.AddOrderCommand, v => v.addOrderButton).DisposeWith(d);
                this.BindCommand(this.ViewModel, vm => vm.EditOrderCommand, v => v.editOrderButton).DisposeWith(d);
                this.BindCommand(this.ViewModel, vm => vm.DeleteOrderCommand, v => v.deleteOrderButton).DisposeWith(d);
            });
        }
    }
}
