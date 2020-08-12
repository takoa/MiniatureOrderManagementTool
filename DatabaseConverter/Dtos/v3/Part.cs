using System;
using System.Collections.Generic;
using System.Text;

namespace MiniatureOrderManagementTool.DatabaseConverter.Dtos.v3
{
    public class Part
    {
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int Count { get; set; }

        public Part(v2.Part v2)
        {
            this.Name = v2.Name;
            this.UnitPrice = v2.UnitPrice;
            this.Count = v2.Count;
        }
    }
}
