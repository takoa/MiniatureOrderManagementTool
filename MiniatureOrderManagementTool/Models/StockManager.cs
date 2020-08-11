using DynamicData;
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
        private SourceCache<StockedPart, string> stockedPartsCache = new SourceCache<StockedPart, string>(s => s.Name);

        public IObservableCollection<StockedPart> StockedParts { get; } = new ObservableCollectionExtended<StockedPart>();

        public event Action StockCountChanged;

        public StockManager()
        {
            this.InitializeOrders();
        }

        public void AddStockedPart(StockedPart stockedPart)
        {
            if (stockedPart == null)
            {
                return;
            }

            using var db = new LiteDatabase(StockManager.databasePath);
            var collection = db.GetCollection<StockedPart>("parts");

            collection.Insert(stockedPart);
            collection.EnsureIndex(sp => sp.ID, true);
            this.stockedPartsCache.AddOrUpdate(stockedPart);
        }

        public void RemoveStockedPart(StockedPart stockedParts)
        {
            if (stockedParts == null)
            {
                return;
            }

            using var db = new LiteDatabase(StockManager.databasePath);
            var collection = db.GetCollection<StockedPart>("parts");

            if (collection.Delete(stockedParts.ID))
            {
                this.stockedPartsCache.RemoveKey(stockedParts.Name);
            }
        }

        private void InitializeOrders()
        {
            using var db = new LiteDatabase(StockManager.databasePath);
            var collection = db.GetCollection<StockedPart>("parts");
            var observable = this.stockedPartsCache.Connect()
                                 .ObserveOn(RxApp.MainThreadScheduler)
                                 .Sort(new StockedPartNameComparer())
                                 .Bind(this.StockedParts);

            this.stockedPartsCache.Connect()
                               .ObserveOn(RxApp.MainThreadScheduler)
                               .Sort(new StockedPartNameComparer())
                               .Bind(this.StockedParts)
                               .WhenAnyPropertyChanged("Name", "Count", "UnitPrice", "MaterialCost", "TimeSpent")
                               .Subscribe(this.WhenChanged);
            this.stockedPartsCache.Connect()
                               .ObserveOn(RxApp.MainThreadScheduler)
                               .WhenValueChanged(sp => sp.Count)
                               .Subscribe(_ => this.StockCountChanged?.Invoke());

            this.stockedPartsCache.AddOrUpdate(collection.FindAll());
        }

        private void WhenChanged(StockedPart stockedPart)
        {
            using var db = new LiteDatabase(StockManager.databasePath);
            var collection = db.GetCollection<StockedPart>("parts");

            stockedPart.ModifiedAt = DateTime.Now;
            collection.Update(stockedPart);
        }
    }
}
