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

        public IObservableCollection<StockedPart> StockedParts => this.stockManager.StockedParts;

        private StockedPart selectedStockedPart;
        public StockedPart SelectedStockedPart
        {
            get => this.selectedStockedPart;
            set => this.RaiseAndSetIfChanged(ref this.selectedStockedPart, value);
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

        public ReactiveCommand<Unit, Unit> AddStockedPartCommand { get; }
        public ReactiveCommand<Unit, Unit> RemoveStockedPartCommand { get; }

        public StockViewModel()
        {
            this.AddStockedPartCommand = ReactiveCommand.Create(this.AddStockedPart);
            this.RemoveStockedPartCommand = ReactiveCommand.Create(this.RemoveStockedPart);
            this.stockManager.StockCountChanged += this.StockCountChanged;
            this.stockManager.StockedParts.CollectionChanged += (s, e) => this.StockCountChanged();
        }

        private void AddStockedPart()
        {
            DateTime currentTime = DateTime.Now;
            StockedPart sp = new StockedPart()
            {
                Name = this.Name,
                Count = this.Count,
                UnitPrice = this.UnitPrice,
                MaterialCost = this.MaterialCost,
                TimeSpent = this.TimeSpent,
                CreatedAt = currentTime,
                ModifiedAt = currentTime,
            };

            this.stockManager.AddStockedPart(sp);

            this.Name = "";
            this.Count = 0;
            this.UnitPrice = 0m;
            this.MaterialCost = 0m;
            this.TimeSpent = 0m;
        }

        private void RemoveStockedPart()
        {
            this.stockManager.RemoveStockedPart(this.SelectedStockedPart);
        }

        private void StockCountChanged()
        {
            this.TotalStockValue = this.stockManager.StockedParts.Sum(sp => sp.UnitPrice * sp.Count);
        }
    }
}
