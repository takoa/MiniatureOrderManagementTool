using ReactiveUI;

namespace MiniatureOrderManagementTool.Models.Dtos
{
    public class Part
    {
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int Count { get; set; }

        public Part()
        {
        }

        public Part(Models.Part part)
        {
            this.Name = part.Name;
            this.UnitPrice = part.UnitPrice;
            this.Count = part.Count;
        }
    }
}
