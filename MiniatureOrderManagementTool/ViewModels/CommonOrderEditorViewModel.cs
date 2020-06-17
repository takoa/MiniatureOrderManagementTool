using DynamicData;
using MiniatureOrderManagementTool.Dtos;
using MiniatureOrderManagementTool.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Linq;

namespace MiniatureOrderManagementTool.ViewModels
{
    public class CommonOrderEditorViewModel : ViewModelBase
    {
        private Order order;
        public Order Order
        {
            get => this.Order;
            set
            {
                this.order = value;
                this.OrderName = value.Name;
                this.OrderDeadline = value.Deadline;
                this.OrderCustomer = value.Customer;
                this.OrderPrice = value.Price;
                this.OrderDescription = value.Description;
                this.PartsCache.AddOrUpdate(value.Parts);
            }
        }

        private string orderName;
        public string OrderName
        {
            get => this.orderName;
            set => this.RaiseAndSetIfChanged(ref this.orderName, value);
        }

        private string orderCustomer;
        public string OrderCustomer
        {
            get => this.orderCustomer;
            set => this.RaiseAndSetIfChanged(ref this.orderCustomer, value);
        }

        private DateTime orderDeadline;
        public DateTime OrderDeadline
        {
            get => this.orderDeadline;
            set => this.RaiseAndSetIfChanged(ref this.orderDeadline, value);
        }

        private string orderDescription;
        public string OrderDescription
        {
            get => this.orderDescription;
            set => this.RaiseAndSetIfChanged(ref this.orderDescription, value);
        }

        private decimal orderPrice;
        public decimal OrderPrice
        {
            get => this.orderPrice;
            set => this.RaiseAndSetIfChanged(ref this.orderPrice, value);
        }

        private string partName;
        public string PartName
        {
            get => this.partName;
            set => this.RaiseAndSetIfChanged(ref this.partName, value);
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

        private SourceCache<Part, string> partsCache;
        public SourceCache<Part, string> PartsCache
        {
            get => this.partsCache;
            set => this.RaiseAndSetIfChanged(ref this.partsCache, value);
        }

        private ReadOnlyObservableCollection<Part> parts;
        public ReadOnlyObservableCollection<Part> Parts => this.parts;

        public ReactiveCommand<Unit, Unit> AddPartCommand { get; }
        public ReactiveCommand<Unit, Unit> RemovePartCommand { get; }

        public CommonOrderEditorViewModel()
        {
            this.orderDeadline = DateTime.Now;

            this.PartsCache = new SourceCache<Part, string>(p => p.Name);
            this.PartsCache.Connect()
                           .ObserveOn(RxApp.MainThreadScheduler)
                           .Sort(new PartNameComparer())
                           .Bind(out this.parts)
                           .Subscribe();

            this.AddPartCommand = ReactiveCommand.Create(this.AddPart);
            this.RemovePartCommand = ReactiveCommand.Create(this.RemovePart);
        }

        public static int GetPartAmountInt(string str)
        {
            int i;

            if (Int32.TryParse(str, out i))
            {
                return i;
            }
            else if (str == "" || i < 0)
            {
                return 0;
            }
            else
            {
                return int.MaxValue;
            }
        }

        private void AddPart()
        {
            if (this.PartName == "" || this.PartAmount == 0)
            {
                return;
            }

            var part = new Part
            {
                Name = PartName,
                Count = PartAmount
            };

            this.PartsCache.AddOrUpdate(part);
            this.PartName = "";
            this.PartAmount = 0;
        }

        private void RemovePart()
        {
            this.PartsCache.Remove(this.SelectedPart);
        }
    }
}
