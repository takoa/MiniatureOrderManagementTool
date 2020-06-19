using MiniatureOrderManagementTool.Dtos;
using MiniatureOrderManagementTool.Models;
using ReactiveUI;
using System;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows;

namespace MiniatureOrderManagementTool.ViewModels
{
    public class NewOrderViewModel : ViewModelBase
    {
        private Config config;

        public OrderManager OrderManager { get; }
        public CommonOrderEditorViewModel CommonOrderEditorViewModel { get; set; }

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

        public ReactiveCommand<IClosable, Unit> AddOrderCommand { get; }
        public ReactiveCommand<IClosable, Unit> CancelCommand { get; }

        public NewOrderViewModel(Config config, OrderManager orderManager)
        {
            this.config = config;
            this.OrderManager = orderManager;

            this.Left = this.config.MainWindowPosition.X + this.config.OrderEditorWindowDelta.X;
            this.Top = this.config.MainWindowPosition.Y + this.config.OrderEditorWindowDelta.Y;
            this.Width = this.config.OrderEditorWindowSize.Width;
            this.Height = this.config.OrderEditorWindowSize.Height;

            this.AddOrderCommand = ReactiveCommand.Create<IClosable>(this.AddOrder);
            this.CancelCommand = ReactiveCommand.Create<IClosable>(this.Cancel);
        }

        private void AddOrder(IClosable closable)
        {
            DateTime now = DateTime.Now;
            Order order = new Order
            {
                IsFinished = false,
                Name = this.CommonOrderEditorViewModel.OrderName,
                Price = this.CommonOrderEditorViewModel.OrderPrice,
                Description = this.CommonOrderEditorViewModel.OrderDescription,
                Customer = this.CommonOrderEditorViewModel.OrderCustomer,
                CreatedAt = now,
                ModifiedAt = now,
                Deadline = this.CommonOrderEditorViewModel.OrderDeadline,
                Parts = this.CommonOrderEditorViewModel.Parts.ToArray(),
                TimeSpent = -1
            };

            this.OrderManager.AddOrder(order);
            closable.Close();
        }

        private void Cancel(IClosable closable)
        {
            closable.Close();
        }
    }
}
