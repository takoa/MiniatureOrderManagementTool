using DynamicData.Binding;
using MiniatureOrderManagementTool.Models;
using MiniatureOrderManagementTool.Models.Dtos;
using ReactiveUI;
using System;
using System.Linq;
using System.Reactive;

namespace MiniatureOrderManagementTool.ViewModels
{
    public class StockViewModel : ViewModelBase
    {
        private StockManager stockManager = new StockManager();

        public IObservableCollection<StockItem> Test => this.stockManager.StockItems;

        private StockItem selectedStockItem;
        public StockItem SelectedStockItem
        {
            get => this.selectedStockItem;
            set => this.RaiseAndSetIfChanged(ref this.selectedStockItem, value);
        }

        private string name;
        public string Name
        {
            get => this.name;
            set => this.RaiseAndSetIfChanged(ref this.name, value);
        }

        private int count;
        public int Count
        {
            get => this.count;
            set => this.RaiseAndSetIfChanged(ref this.count, value);
        }

        private decimal unitPrice;
        public decimal UnitPrice
        {
            get => this.unitPrice;
            set => this.RaiseAndSetIfChanged(ref this.unitPrice, value);
        }

        private decimal materialCost;
        public decimal MaterialCost
        {
            get => this.materialCost;
            set => this.RaiseAndSetIfChanged(ref this.materialCost, value);
        }

        private decimal timeSpent;
        public decimal TimeSpent
        {
            get => this.timeSpent;
            set => this.RaiseAndSetIfChanged(ref this.timeSpent, value);
        }

        private decimal totalStockValue;
        public decimal TotalStockValue
        {
            get => this.totalStockValue;
            set => this.RaiseAndSetIfChanged(ref this.totalStockValue, value);
        }

        public ReactiveCommand<Unit, Unit> AddStockItemCommand { get; }
        public ReactiveCommand<Unit, Unit> RemoveStockItemCommand { get; }

        public StockViewModel()
        {
            this.AddStockItemCommand = ReactiveCommand.Create(this.AddStockItem);
            this.RemoveStockItemCommand = ReactiveCommand.Create(this.RemoveStockItem);
            this.stockManager.StockCountChanged += this.StockCountChanged;
            this.stockManager.StockItems.CollectionChanged += (s, e) => this.StockCountChanged();
        }

        private void AddStockItem()
        {
            DateTime currentTime = DateTime.Now;
            StockItem si = new StockItem()
            {
                Name = this.Name,
                Count = this.Count,
                UnitPrice = this.UnitPrice,
                MaterialCost = this.MaterialCost,
                TimeSpent = this.TimeSpent,
                CreatedAt = currentTime,
                ModifiedAt = currentTime,
            };

            this.stockManager.AddStockItem(si);

            this.Name = "";
            this.Count = 0;
            this.UnitPrice = 0m;
            this.MaterialCost = 0m;
            this.TimeSpent = 0m;
        }

        private void RemoveStockItem()
        {
            this.stockManager.RemoveStockItem(this.SelectedStockItem);
        }

        private void StockCountChanged()
        {
            this.TotalStockValue = this.stockManager.StockItems.Sum(si => si.UnitPrice * si.Count);
        }
    }
}
