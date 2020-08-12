using ReactiveUI;
using System;

namespace MiniatureOrderManagementTool.Models.Dtos
{
    public class StockedPart
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public int Count { get; set; }
        public decimal TimeSpent { get; set; }
        public decimal MaterialCost { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
