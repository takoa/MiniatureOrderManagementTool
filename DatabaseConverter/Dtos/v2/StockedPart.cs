using ReactiveUI;
using System;

namespace MiniatureOrderManagementTool.DatabaseConverter.Dtos.v2
{
    public class StockedPart : ReactiveObject
    {
        private int id;
        public int ID
        {
            get => this.id;
            set => this.RaiseAndSetIfChanged(ref this.id, value);
        }

        private string name;
        public string Name
        {
            get => this.name;
            set => this.RaiseAndSetIfChanged(ref this.name, value);
        }

        private DateTime createdAt;
        public DateTime CreatedAt
        {
            get => this.createdAt;
            set => this.RaiseAndSetIfChanged(ref this.createdAt, value);
        }

        private DateTime modifiedAt;
        public DateTime ModifiedAt
        {
            get => this.modifiedAt;
            set => this.RaiseAndSetIfChanged(ref this.modifiedAt, value);
        }

        private int count;
        public int Count
        {
            get => this.count;
            set => this.RaiseAndSetIfChanged(ref this.count, value);
        }

        private decimal timeSpent;
        public decimal TimeSpent
        {
            get => this.timeSpent;
            set => this.RaiseAndSetIfChanged(ref this.timeSpent, value);
        }

        private decimal materialCost;
        public decimal MaterialCost
        {
            get => this.materialCost;
            set => this.RaiseAndSetIfChanged(ref this.materialCost, value);
        }

        private decimal unitPrice;
        public decimal UnitPrice
        {
            get => this.unitPrice;
            set => this.RaiseAndSetIfChanged(ref this.unitPrice, value);
        }
    }
}
