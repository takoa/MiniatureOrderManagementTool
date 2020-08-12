using ReactiveUI;

namespace MiniatureOrderManagementTool.Models
{
    public class Part : ReactiveObject
    {
        private string name;
        public string Name
        {
            get => this.name;
            set => this.RaiseAndSetIfChanged(ref this.name, value);
        }

        private decimal unitPrice;
        public decimal UnitPrice
        {
            get => this.unitPrice;
            set => this.RaiseAndSetIfChanged(ref this.unitPrice, value);
        }

        private int count;
        public int Count
        {
            get => this.count;
            set => this.RaiseAndSetIfChanged(ref this.count, value);
        }

        public Part()
        {
        }

        public Part(Dtos.Part part)
        {
            this.Name = part.Name;
            this.UnitPrice = part.UnitPrice;
            this.Count = part.Count;
        }

        public Part(string name, decimal unitPrice, int count)
        {
            this.Name = name;
            this.UnitPrice = unitPrice;
            this.Count = count;
        }
    }
}
