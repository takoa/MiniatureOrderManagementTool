﻿using DynamicData;
using DynamicData.Binding;
using LiteDB;
using MiniatureOrderManagementTool.Models.Dtos;
using ReactiveUI;
using System;
using System.Reactive.Linq;

namespace MiniatureOrderManagementTool.Models
{
    public class StockManager
    {
        private const string databasePath = "./database.db";
        private SourceCache<StockItem, string> stockItemCache = new SourceCache<StockItem, string>(s => s.Name);

        public IObservableCollection<StockItem> StockItems { get; } = new ObservableCollectionExtended<StockItem>();

        public event Action StockCountChanged;

        public StockManager()
        {
            this.InitializeOrders();
        }

        public void AddStockItem(StockItem stockItem)
        {
            if (stockItem == null)
            {
                return;
            }

            using var db = new LiteDatabase(StockManager.databasePath);
            var collection = db.GetCollection<StockItem>("parts");

            collection.Insert(stockItem);
            collection.EnsureIndex(si => si.ID, true);
            this.stockItemCache.AddOrUpdate(stockItem);
        }

        public void RemoveStockItem(StockItem stockItem)
        {
            if (stockItem == null)
            {
                return;
            }

            using var db = new LiteDatabase(StockManager.databasePath);
            var collection = db.GetCollection<StockItem>("parts");

            if (collection.Delete(stockItem.ID))
            {
                this.stockItemCache.RemoveKey(stockItem.Name);
            }
        }

        private void InitializeOrders()
        {
            using var db = new LiteDatabase(StockManager.databasePath);
            var collection = db.GetCollection<StockItem>("parts");
            var observable = this.stockItemCache.Connect()
                                 .ObserveOn(RxApp.MainThreadScheduler)
                                 .Sort(new StockItemNameComparer())
                                 .Bind(this.StockItems);

            this.stockItemCache.Connect()
                               .ObserveOn(RxApp.MainThreadScheduler)
                               .Sort(new StockItemNameComparer())
                               .Bind(this.StockItems)
                               .WhenAnyPropertyChanged("Name", "Count", "UnitPrice", "MaterialCost", "TimeSpent")
                               .Subscribe(this.WhenChanged);
            this.stockItemCache.Connect()
                               .ObserveOn(RxApp.MainThreadScheduler)
                               .WhenValueChanged(si => si.Count)
                               .Subscribe(count => this.StockCountChanged?.Invoke());

            this.stockItemCache.AddOrUpdate(collection.FindAll());
        }

        private void WhenChanged(StockItem stockItem)
        {
            stockItem.ModifiedAt = DateTime.Now;
        }
    }
}
