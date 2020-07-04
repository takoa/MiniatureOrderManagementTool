using LiteDB;
using MiniatureOrderManagementTool.Dtos;
using MiniatureOrderManagementTool.Models;
using ReactiveUI;
using System;
using System.Reactive;
using System.Windows;

namespace MiniatureOrderManagementTool.ViewModels
{
    public class OrderEditorViewModel : CommonOrderEditorViewModel
    {
        private Config config;
        private OrderManager orderManager;
        private Order selectedOrder;

        private double left;
        public double Left
        {
            get => this.left;
            set
            {
                this.RaiseAndSetIfChanged(ref this.left, value);
                this.config.OrderEditorWindowDelta = new Point(value - this.config.MainWindowPosition.X, this.config.OrderEditorWindowDelta.Y);
            }
        }

        private double top;
        public double Top
        {
            get => this.top;
            set
            {
                this.RaiseAndSetIfChanged(ref this.top, value);
                this.config.OrderEditorWindowDelta = new Point(this.config.OrderEditorWindowDelta.X, value - this.config.MainWindowPosition.Y);
            }
        }

        private double width;
        public double Width
        {
            get => this.width;
            set
            {
                this.RaiseAndSetIfChanged(ref this.width, value);
                this.config.OrderEditorWindowSize = new Size(value, this.config.OrderEditorWindowSize.Height);
            }
        }

        private double height;
        public double Height
        {
            get => this.height;
            set
            {
                this.RaiseAndSetIfChanged(ref this.height, value);
                this.config.OrderEditorWindowSize = new Size(this.config.OrderEditorWindowSize.Width, value);
            }
        }

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

        public ReactiveCommand<IClosable, Unit> UpdateOrderCommand { get; }
        public ReactiveCommand<IClosable, Unit> CancelCommand { get; }

        public OrderEditorViewModel(Config config, OrderManager orderManager, Order selectedOrder)
        {
            this.config = config;
            this.orderManager = orderManager;
            this.selectedOrder = selectedOrder;

            this.Name = selectedOrder.Name;
            this.Price = selectedOrder.Price;
            this.Description = selectedOrder.Description;
            this.Customer = selectedOrder.Customer;
            this.Deadline = selectedOrder.Deadline;
            this.PartManager.Parts = selectedOrder.Parts;
            this.Left = this.config.MainWindowPosition.X + this.config.OrderEditorWindowDelta.X;
            this.Top = this.config.MainWindowPosition.Y + this.config.OrderEditorWindowDelta.Y;
            this.Width = this.config.OrderEditorWindowSize.Width;
            this.Height = this.config.OrderEditorWindowSize.Height;
            this.IsOrderFinished = this.selectedOrder.IsFinished;
            this.OrderTimeSpent = this.selectedOrder.TimeSpent;

            this.UpdateOrderCommand = ReactiveCommand.Create<IClosable>(this.UpdateOrder);
            this.CancelCommand = ReactiveCommand.Create<IClosable>(this.Cancel);
        }

        private void UpdateOrder(IClosable closable)
        {
            Order order = new Order
            {
                ID = this.selectedOrder.ID,
                ObjectID = ObjectId.NewObjectId(),
                IsFinished = this.IsOrderFinished ?? false,
                Name = this.Name,
                Price = this.Price,
                Description = this.Description,
                Customer = this.Customer,
                CreatedAt = this.selectedOrder.CreatedAt,
                ModifiedAt = DateTime.Now,
                Deadline = this.Deadline,
                Parts = this.PartManager.Parts,
                TimeSpent = OrderTimeSpent
            };

            this.orderManager.UpdateOrder(order);
            closable.Close();
        }

        private void Cancel(IClosable closable)
        {
            closable.Close();
        }
    }
}
