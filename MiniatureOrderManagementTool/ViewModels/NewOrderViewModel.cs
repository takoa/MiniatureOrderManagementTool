using MiniatureOrderManagementTool.Models;
using ReactiveUI;
using System;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;

namespace MiniatureOrderManagementTool.ViewModels
{
    public class NewOrderViewModel : ViewModelBase
    {
        public OrderListViewModel OrderListViewModel { get; }
        public CommonOrderEditorViewModel CommonOrderEditorViewModel { get; set; }

        public ReactiveCommand<IClosable, Unit> AddOrderCommand { get; }
        public ReactiveCommand<IClosable, Unit> CancelCommand { get; }

        public NewOrderViewModel(OrderListViewModel orderListViewModel)
        {
            this.OrderListViewModel = orderListViewModel;

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

            this.OrderListViewModel.AddOrder(order);
            closable.Close();
        }

        private void Cancel(IClosable closable)
        {
            closable.Close();
        }
    }
}
