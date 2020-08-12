using System;
using System.Collections.Generic;
using System.Text;

namespace MiniatureOrderManagementTool.DatabaseConverter.Dtos.v3
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

        public StockedPart(v2.StockedPart v2)
        {
            this.ID = v2.ID;
            this.Name = v2.Name;
            this.CreatedAt = v2.CreatedAt;
            this.ModifiedAt = v2.ModifiedAt;
            this.Count = v2.Count;
            this.TimeSpent = v2.TimeSpent;
            this.MaterialCost = v2.MaterialCost;
            this.UnitPrice = v2.UnitPrice;
        }
    }
}
