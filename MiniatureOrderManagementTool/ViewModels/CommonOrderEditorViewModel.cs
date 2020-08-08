using DynamicData.Binding;
using MiniatureOrderManagementTool.Models;
using MiniatureOrderManagementTool.Models.Dtos;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Reactive;

namespace MiniatureOrderManagementTool.ViewModels
{
    public class CommonOrderEditorViewModel : ViewModelBase
    {
        public PartManager PartManager { get; } = new PartManager();
        public StockManager StockManager { get; } = new StockManager();

        private string name;
        public string Name
        {
            get => this.name;
            set => this.RaiseAndSetIfChanged(ref this.name, value);
        }

        private string customer;
        public string Customer
        {
            get => this.customer;
            set => this.RaiseAndSetIfChanged(ref this.customer, value);
        }

        private DateTime deadline;
        public DateTime Deadline
        {
            get => this.deadline;
            set => this.RaiseAndSetIfChanged(ref this.deadline, value);
        }

        private string description;
        public string Description
        {
            get => this.description;
            set => this.RaiseAndSetIfChanged(ref this.description, value);
        }

        private decimal price;
        public decimal Price
        {
            get => this.price;
            set => this.RaiseAndSetIfChanged(ref this.price, value);
        }

        private decimal discount;
        public decimal Discount
        {
            get => this.discount;
            set => this.RaiseAndSetIfChanged(ref this.discount, value);
        }

        private int totalPartCount;
        public int TotalPartCount
        {
            get => this.totalPartCount;
            set => this.RaiseAndSetIfChanged(ref this.totalPartCount, value);
        }

        private decimal totalPartValue;
        public decimal TotalPartValue
        {
            get => this.totalPartValue;
            set => this.RaiseAndSetIfChanged(ref this.totalPartValue, value);
        }

        private string partName;
        public string PartName
        {
            get => this.partName;
            set => this.RaiseAndSetIfChanged(ref this.partName, value);
        }

        private decimal partUnitPrice;
        public decimal PartUnitPrice
        {
            get => this.partUnitPrice;
            set => this.RaiseAndSetIfChanged(ref this.partUnitPrice, value);
        }

        private int partAmount;
        public int PartAmount
        {
            get => this.partAmount;
            set => this.RaiseAndSetIfChanged(ref this.partAmount, value);
        }

        private Part selectedPart;
        public Part SelectedPart
        {
            get => this.selectedPart;
            set => this.RaiseAndSetIfChanged(ref this.selectedPart, value);
        }

        private StockedPart selectedStockedPart;
        public StockedPart SelectedStockedPart
        {
            get => this.selectedStockedPart;
            set => this.RaiseAndSetIfChanged(ref this.selectedStockedPart, value);
        }

        public ReadOnlyObservableCollection<Part> ObservableParts => this.PartManager.ObservableParts;
        public IObservableCollection<StockedPart> StockedParts => this.StockManager.StockedParts;

        public ReactiveCommand<Unit, Unit> AddPartCommand { get; }
        public ReactiveCommand<Unit, Unit> RemovePartCommand { get; }
        public ReactiveCommand<Unit, Unit> AddStockedPartCommand { get; }

        public CommonOrderEditorViewModel()
        {
            this.Deadline = DateTime.Now;

            ((INotifyCollectionChanged)this.PartManager.ObservableParts).CollectionChanged += this.PartCollectionChanged;

            this.AddPartCommand = ReactiveCommand.Create(this.AddPart);
            this.RemovePartCommand = ReactiveCommand.Create(this.RemovePart);
            this.AddStockedPartCommand = ReactiveCommand.Create(this.AddStockedPart);
        }

        private void PartCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            var count = 0;
            var value = 0m;

            foreach (var item in this.ObservableParts)
            {
                count += item.Count;
                value += item.UnitPrice * item.Count;
            }

            this.TotalPartCount = count;
            this.TotalPartValue = value;
        }

        private void AddPart()
        {
            if (this.PartName == "" || this.PartAmount == 0)
            {
                return;
            }

            var part = new Part(this.PartName, this.PartUnitPrice, this.PartAmount);

            this.PartManager.AddPart(part);
            this.PartName = "";
            this.PartUnitPrice = 0m;
            this.PartAmount = 0;
        }

        private void RemovePart()
        {
            if (this.SelectedPart == null)
            {
                return;
            }

            this.PartManager.RemovePart(this.selectedPart);
        }

        private void AddStockedPart()
        {
            if (this.SelectedStockedPart == null)
            {
                return;
            }

            if (this.PartManager.TryGetPart(this.SelectedStockedPart.Name, out Part part))
            {
                part.Count++;
            }
            else
            {
                part = new Part(this.SelectedStockedPart.Name, this.SelectedStockedPart.UnitPrice, 1);
            }

            this.PartManager.AddPart(part);
        }
    }
}
