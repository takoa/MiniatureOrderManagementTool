using LiteDB;
using MiniatureOrderManagementTool.Models;
using ReactiveUI;
using System;
using System.Linq;
using System.Reactive;
using System.Windows;

namespace MiniatureOrderManagementTool.ViewModels
{
    public class OrderEditorViewModel : ViewModelBase
    {
        private Config config;

        public OrderListViewModel OrderListViewModel { get; }

        private CommonOrderEditorViewModel commonOrderEditorViewModel;
        public CommonOrderEditorViewModel CommonOrderEditorViewModel
        {
            get => this.commonOrderEditorViewModel;
            set
            {
                this.commonOrderEditorViewModel = value;
                value.Order = this.OrderListViewModel.SelectedOrder;
            }
        }

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

        public OrderEditorViewModel(Config config, OrderListViewModel orderListViewModel)
        {
            this.config = config;
            this.OrderListViewModel = orderListViewModel;

            this.Left = this.config.MainWindowPosition.X + this.config.OrderEditorWindowDelta.X;
            this.Top = this.config.MainWindowPosition.Y + this.config.OrderEditorWindowDelta.Y;
            this.Width = this.config.OrderEditorWindowSize.Width;
            this.Height = this.config.OrderEditorWindowSize.Height;
            this.IsOrderFinished = this.OrderListViewModel.SelectedOrder.IsFinished;
            this.OrderTimeSpent = this.OrderListViewModel.SelectedOrder.TimeSpent;

            this.UpdateOrderCommand = ReactiveCommand.Create<IClosable>(this.UpdateOrder);
            this.CancelCommand = ReactiveCommand.Create<IClosable>(this.Cancel);
        }

        private void UpdateOrder(IClosable closable)
        {
            Order order = new Order
            {
                ID = this.OrderListViewModel.SelectedOrder.ID,
                ObjectID = ObjectId.NewObjectId(),
                IsFinished = this.IsOrderFinished ?? false,
                Name = this.CommonOrderEditorViewModel.OrderName,
                Price = this.CommonOrderEditorViewModel.OrderPrice,
                Description = this.CommonOrderEditorViewModel.OrderDescription,
                Customer = this.CommonOrderEditorViewModel.OrderCustomer,
                CreatedAt = this.OrderListViewModel.SelectedOrder.CreatedAt,
                ModifiedAt = DateTime.Now,
                Deadline = this.CommonOrderEditorViewModel.OrderDeadline,
                Parts = this.CommonOrderEditorViewModel.Parts.ToArray(),
                TimeSpent = OrderTimeSpent
            };

            this.OrderListViewModel.UpdateOrder(order);
            closable.Close();
        }

        private void Cancel(IClosable closable)
        {
            closable.Close();
        }
    }
}
