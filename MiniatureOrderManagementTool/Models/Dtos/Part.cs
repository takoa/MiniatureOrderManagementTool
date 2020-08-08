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

        public Part(string name, decimal unitPrice, int count)
        {
            this.Name = name;
            this.UnitPrice = unitPrice;
            this.Count = count;
        }
    }
}
