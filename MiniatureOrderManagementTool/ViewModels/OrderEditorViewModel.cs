using LiteDB;
using MiniatureOrderManagementTool.Models;
using ReactiveUI;
using System;
using System.Reactive;
using System.Windows;

namespace MiniatureOrderManagementTool.ViewModels
{
    public class OrderEditorViewModel : OrderEditorViewModelBase
    {
        private OrderManager orderManager;
        private Order selectedOrder;

        private bool? isOrderFinished;
        public bool? IsOrderFinished
        {
            get => this.isOrderFinished;
            set => this.RaiseAndSetIfChanged(ref this.isOrderFinished, value);
        }

        private decimal orderTimeSpent;
        public decimal OrderTimeSpent
        {
            get => this.orderTimeSpent;
            set => this.RaiseAndSetIfChanged(ref this.orderTimeSpent, value);
        }

        public ReactiveCommand<Unit, Unit> UpdateOrderCommand { get; }

        public OrderEditorViewModel(Config config, OrderManager orderManager, Order selectedOrder)
            : base(config, selectedOrder)
        {
            this.orderManager = orderManager;
            this.selectedOrder = selectedOrder;

            this.IsOrderFinished = this.selectedOrder.IsFinished;
            this.OrderTimeSpent = this.selectedOrder.TimeSpent;

            this.UpdateOrderCommand = ReactiveCommand.Create(this.UpdateOrder);
        }

        private void UpdateOrder()
        {
            Order order = new Order
            {
                ID = this.selectedOrder.ID,
                ObjectID = ObjectId.NewObjectId(),
                IsFinished = this.IsOrderFinished ?? false,
                Name = this.Name,
                Price = this.Price,
                Discount = this.Discount,
                Description = this.Description,
                Customer = this.Customer,
                CreatedAt = this.selectedOrder.CreatedAt,
                ModifiedAt = DateTime.Now,
                Deadline = this.Deadline,
                Parts = this.PartManager.Parts,
                TimeSpent = OrderTimeSpent
            };

            this.orderManager.AddOrUpdateOrder(order);
            this.ShowsConfirmation = false;
            this.Window.Close();
        }
    }
}
