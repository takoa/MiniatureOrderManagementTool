using DynamicData;
using LiteDB;
using MinitureOrderManagementTool.Helpers;
using MinitureOrderManagementTool.Models;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;

namespace MinitureOrderManagementTool.ViewModels
{
    public class OrderListViewModel : ViewModelBase
    {
        private string databasePath;

        private SourceCache<Order, int> ordersCache;
        public SourceCache<Order, int> OrdersCache
        {
            get => this.ordersCache;
            set => this.RaiseAndSetIfChanged(ref this.ordersCache, value);
        }

        private ReadOnlyObservableCollection<Order> orders;
        public ReadOnlyObservableCollection<Order> Orders => this.orders;

        private Order selectedOrder;
        public Order SelectedOrder
        {
            get => this.selectedOrder;
            set => this.RaiseAndSetIfChanged(ref this.selectedOrder, value);
        }

        public ReactiveCommand<Unit, Unit> AddOrderCommand { get; }
        public ReactiveCommand<Unit, Unit> EditOrderCommand { get; }
        public ReactiveCommand<Unit, Unit> DeleteOrderCommand { get; }

        public OrderListViewModel(string databasePath)
        {
            this.databasePath = databasePath;
            this.InitializeOrders();

            this.AddOrderCommand = ReactiveCommand.Create(this.CreateNewOrderWindow);
            this.EditOrderCommand = ReactiveCommand.Create(this.CreateOrderEditorWindow);
            this.DeleteOrderCommand = ReactiveCommand.Create(this.DeleteOrder);
        }

        public static string GetIsFinishedString(bool isFinished)
        {
            return isFinished ? "Š®—¹" : "–¢Š®—¹";
        }

        public static string GetTimeSpentString(decimal timeSpent)
        {
            if (0 <= timeSpent)
            {
                return timeSpent + "ŽžŠÔ";
            }
            else
            {
                return "–¢Ý’è";
            }
        }

        public static string GetDeadlineString(DateTime deadline)
        {
            return deadline.ToString("yyyy”NMMŒŽdd“ú");
        }

        public void AddOrder(Order order)
        {
            using (var db = new LiteDatabase(this.databasePath))
            {
                var orders = db.GetCollection<Order>("orders");

                orders.Insert(order);
                orders.EnsureIndex(x => x.ID, true);
                this.OrdersCache.AddOrUpdate(order);
            }
        }

        public void UpdateOrder(Order order)
        {
            using (var db = new LiteDatabase(this.databasePath))
            {
                var orders = db.GetCollection<Order>("orders");

                orders.Update(order);
                this.OrdersCache.AddOrUpdate(order);
            }

            this.SelectedOrder = order;
        }

        private void InitializeOrders()
        {
            using var db = new LiteDatabase(databasePath);
            var collection = db.GetCollection<Order>("orders");

            this.OrdersCache = new SourceCache<Order, int>(i => i.ID);
            this.OrdersCache.Connect()
                            .ObserveOn(RxApp.MainThreadScheduler)
                            .Sort(new OrderDeadlineComparer())
                            .Bind(out this.orders)
                            .Subscribe();
            this.OrdersCache.AddOrUpdate(collection.FindAll());

            foreach (var order in this.OrdersCache.Items.OrderBy(o => o.Deadline))
            {
                if (!order.IsFinished && order.Deadline < DateTime.Now)
                {
                    this.SelectedOrder = order;

                    break;
                }
            }
        }

        private void CreateNewOrderWindow()
        {
            var newOrderViewModel = new NewOrderViewModel(this);

            WindowViewHelper.ShowWindow(newOrderViewModel);
        }

        private void CreateOrderEditorWindow()
        {
            if (this.SelectedOrder == null)
            {
                return;
            }

            var orderEditorViewModel = new OrderEditorViewModel(this);

            WindowViewHelper.ShowWindow(orderEditorViewModel);
        }

        private void DeleteOrder()
        {
            if (this.SelectedOrder == null)
            {
                return;
            }

            using (var db = new LiteDatabase(this.databasePath))
            {
                var orders = db.GetCollection<Order>("orders");

                orders.Delete(this.SelectedOrder.ID);
                this.OrdersCache.RemoveKey(this.selectedOrder.ID);
            }
        }
    }
}
