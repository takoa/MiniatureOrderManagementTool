using MiniatureOrderManagementTool.Models;
using MiniatureOrderManagementTool.Models.Dtos;
using ReactiveUI;
using System;
using System.Reactive;
using System.Windows;

namespace MiniatureOrderManagementTool.ViewModels
{
    public class NewOrderViewModel : OrderEditorViewModelBase
    {
        private Config config;

        public OrderManager OrderManager { get; }

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

        public ReactiveCommand<Unit, Unit> AddOrderCommand { get; }
        public ReactiveCommand<Unit, Unit> CancelCommand { get; }

        public NewOrderViewModel(Config config, OrderManager orderManager)
        {
            this.config = config;
            this.OrderManager = orderManager;

            this.Left = this.config.MainWindowPosition.X + this.config.OrderEditorWindowDelta.X;
            this.Top = this.config.MainWindowPosition.Y + this.config.OrderEditorWindowDelta.Y;
            this.Width = this.config.OrderEditorWindowSize.Width;
            this.Height = this.config.OrderEditorWindowSize.Height;

            this.AddOrderCommand = ReactiveCommand.Create(this.AddOrder);
            this.CancelCommand = ReactiveCommand.Create(this.Cancel);
        }

        private void AddOrder()
        {
            DateTime now = DateTime.Now;
            Order order = new Order
            {
                IsFinished = false,
                Name = this.Name,
                Price = this.Price,
                Description = this.Description,
                Customer = this.Customer,
                CreatedAt = now,
                ModifiedAt = now,
                Deadline = this.Deadline,
                Parts = this.PartManager.Parts,
                TimeSpent = -1
            };

            this.OrderManager.AddOrder(order);
            this.Window.Close();
        }
    }
}
