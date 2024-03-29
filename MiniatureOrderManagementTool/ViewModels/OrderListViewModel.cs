using MiniatureOrderManagementTool.Helpers;
using MiniatureOrderManagementTool.Models;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Windows;

namespace MiniatureOrderManagementTool.ViewModels
{
    public class OrderListViewModel : ViewModelBase
    {
        private OrderManager orderManager = new OrderManager();

        public ReadOnlyObservableCollection<Order> Orders => this.orderManager.Orders;

        private Order selectedOrder;
        public Order SelectedOrder
        {
            get => this.selectedOrder;
            set => this.RaiseAndSetIfChanged(ref this.selectedOrder, value);
        }

        public ReactiveCommand<Unit, Unit> AddOrderCommand { get; }
        public ReactiveCommand<Unit, Unit> EditOrderCommand { get; }
        public ReactiveCommand<Unit, Unit> DeleteOrderCommand { get; }

        public OrderListViewModel()
        {
            this.AddOrderCommand = ReactiveCommand.Create(this.CreateNewOrderWindow);
            this.EditOrderCommand = ReactiveCommand.Create(this.CreateOrderEditorWindow);
            this.DeleteOrderCommand = ReactiveCommand.Create(this.DeleteOrder);
        }

        private void CreateNewOrderWindow()
        {
            var newOrderViewModel = new NewOrderViewModel(this.orderManager);

            WindowViewHelper.ShowWindow(newOrderViewModel);
        }

        private void CreateOrderEditorWindow()
        {
            if (this.SelectedOrder == null)
            {
                return;
            }

            var orderEditorViewModel = new OrderEditorViewModel(this.orderManager, this.SelectedOrder);

            WindowViewHelper.ShowWindow(orderEditorViewModel);
        }

        private void DeleteOrder()
        {
            this.orderManager.DeleteOrder(this.SelectedOrder);
        }
    }
}
