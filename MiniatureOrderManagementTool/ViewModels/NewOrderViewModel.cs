using MiniatureOrderManagementTool.Models;
using ReactiveUI;
using System;
using System.Reactive;
using System.Windows;

namespace MiniatureOrderManagementTool.ViewModels
{
    public class NewOrderViewModel : OrderEditorViewModelBase
    {
        public OrderManager OrderManager { get; }

        public ReactiveCommand<Unit, Unit> AddOrderCommand { get; }

        public NewOrderViewModel(Config config, OrderManager orderManager)
            : base(config)
        {
            this.OrderManager = orderManager;
            this.AddOrderCommand = ReactiveCommand.Create(this.AddOrder);
        }

        private void AddOrder()
        {
            DateTime now = DateTime.Now;
            Order order = new Order
            {
                IsFinished = false,
                Name = this.Name,
                Price = this.Price,
                Discount = this.Discount,
                Description = this.Description,
                Customer = this.Customer,
                CreatedAt = now,
                ModifiedAt = now,
                Deadline = this.Deadline,
                Parts = this.PartManager.Parts,
                TimeSpent = -1
            };

            this.OrderManager.AddOrUpdateOrder(order);
            this.ShowsConfirmation = false;
            this.Window.Close();
        }
    }
}
