using DynamicData;
using MiniatureOrderManagementTool.Dtos;
using MiniatureOrderManagementTool.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;

namespace MiniatureOrderManagementTool.ViewModels
{
    public class CommonOrderEditorViewModel : ViewModelBase, ICommonOrderInfo
    {
        private string name;
        public string Name
        {
            get => this.name;
            set
            {
                this.RaiseAndSetIfChanged(ref this.name, value);
            }
        }

        private string customer;
        public string Customer
        {
            get => this.customer;
            set
            {
                this.RaiseAndSetIfChanged(ref this.customer, value);
            }
        }

        private DateTime deadline;
        public DateTime Deadline
        {
            get => this.deadline;
            set
            {
                this.RaiseAndSetIfChanged(ref this.deadline, value);
            }
        }

        private string description;
        public string Description
        {
            get => this.description;
            set
            {
                this.RaiseAndSetIfChanged(ref this.description, value);
            }
        }

        private decimal price;
        public decimal Price
        {
            get => this.price;
            set
            {
                this.RaiseAndSetIfChanged(ref this.price, value);
            }
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

        private ReadOnlyObservableCollection<Part> observableParts;
        public ReadOnlyObservableCollection<Part> ObservableParts => this.observableParts;

        public Part[] Parts
        {
            get => this.ObservableParts.ToArray();
            set
            {
                if (value != null)
                {
                    this.PartsCache.AddOrUpdate(value);
                }
            }
        }

        public ReactiveCommand<Unit, Unit> AddPartCommand { get; }
        public ReactiveCommand<Unit, Unit> RemovePartCommand { get; }

        public CommonOrderEditorViewModel()
        {
            this.Deadline = DateTime.Now;

            this.PartsCache = new SourceCache<Part, string>(p => p.Name);
            this.PartsCache.Connect()
                           .ObserveOn(RxApp.MainThreadScheduler)
                           .Sort(new PartNameComparer())
                           .Bind(out this.observableParts)
                           .Subscribe();

            this.AddPartCommand = ReactiveCommand.Create(this.AddPart);
            this.RemovePartCommand = ReactiveCommand.Create(this.RemovePart);
        }

        public static int GetPartAmountInt(string str)
        {

            if (Int32.TryParse(str, out int i))
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
