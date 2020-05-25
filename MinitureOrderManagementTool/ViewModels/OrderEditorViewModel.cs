using LiteDB;
using MinitureOrderManagementTool.Models;
using ReactiveUI;
using System;
using System.Linq;
using System.Reactive;

namespace MinitureOrderManagementTool.ViewModels
{
    public class OrderEditorViewModel : ViewModelBase
    {
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

        public OrderEditorViewModel(OrderListViewModel orderListViewModel)
        {
            this.OrderListViewModel = orderListViewModel;

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
