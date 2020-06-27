using DynamicData;
using LiteDB;
using MiniatureOrderManagementTool.Dtos;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;

namespace MiniatureOrderManagementTool.Models
{
    public class OrderManager
    {
        private const string databasePath = "./database.db";

        public SourceCache<Order, int> OrdersCache { get; private set; }

        private ReadOnlyObservableCollection<Order> orders;
        public ReadOnlyObservableCollection<Order> Orders => this.orders;

        public Order OldestUnfinishedOrder
        {
            get
            {
                foreach (var order in this.OrdersCache.Items.OrderBy(o => o.Deadline))
                {
                    if (!order.IsFinished && order.Deadline < DateTime.Now)
                    {
                        return order;
                    }
                }

                return null;
            }
        }

        public OrderManager()
        {
            this.InitializeOrders();
        }

        public static string GetIsFinishedString(bool isFinished)
        {
            return isFinished ? "完了" : "未完了";
        }

        public static string GetTimeSpentString(decimal timeSpent)
        {
            if (0 <= timeSpent)
            {
                return timeSpent + "時間";
            }
            else
            {
                return "未設定";
            }
        }

        public static string GetDeadlineString(DateTime deadline)
        {
            return deadline.ToString("yyyy年MM月dd日");
        }

        public void AddOrder(Order order)
        {
            using (var db = new LiteDatabase(OrderManager.databasePath))
            {
                var orders = db.GetCollection<Order>("orders");

                orders.Insert(order);
                orders.EnsureIndex(x => x.ID, true);
                this.OrdersCache.AddOrUpdate(order);
            }
        }

        public void UpdateOrder(Order order)
        {
            using (var db = new LiteDatabase(OrderManager.databasePath))
            {
                var orders = db.GetCollection<Order>("orders");

                if (orders.Update(order))
                {
                    this.OrdersCache.AddOrUpdate(order);
                }
            }
        }

        public void DeleteOrder(Order order)
        {
            if (order == null)
            {
                return;
            }

            using (var db = new LiteDatabase(OrderManager.databasePath))
            {
                var orders = db.GetCollection<Order>("orders");

                if (orders.Delete(order.ID))
                {
                    this.OrdersCache.RemoveKey(order.ID);
                }
            }
        }

        private void InitializeOrders()
        {
            using var db = new LiteDatabase(OrderManager.databasePath);
            var collection = db.GetCollection<Order>("orders");

            this.OrdersCache = new SourceCache<Order, int>(i => i.ID);
            this.OrdersCache.Connect()
                            .ObserveOn(RxApp.MainThreadScheduler)
                            .Sort(new OrderDeadlineComparer())
                            .Bind(out this.orders)
                            .Subscribe();

            this.OrdersCache.AddOrUpdate(collection.FindAll());
        }
    }
}
