using LiteDB;
using System;

namespace MiniatureOrderManagementTool.DatabaseConverter.Dtos.v3
{
    public class Order
    {
        public int ID { get; set; }
        public ObjectId ObjectID { get; set; }
        public bool IsFinished { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string Customer { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public DateTime Deadline { get; set; }
        public Part[] Parts { get; set; }
        public string Description { get; set; }
        public decimal TimeSpent { get; set; }

        public Order(v2.Order v2)
        {
            this.ID = v2.ID;
            this.ObjectID = v2.ObjectID;
            this.IsFinished = v2.IsFinished;
            this.Name = v2.Name;
            this.CreatedAt = v2.CreatedAt;
            this.ModifiedAt = v2.ModifiedAt;
            this.Customer = v2.Customer;
            this.Price = v2.Price;
            this.Discount = v2.Discount;
            this.Deadline = v2.Deadline;
            this.Description = v2.Description;
            this.TimeSpent = v2.TimeSpent;

            var parts = new Part[v2.Parts.Length];

            for (int i = 0; i < v2.Parts.Length; i++)
            {
                parts[i] = new Part(v2.Parts[i]);
            }

            this.Parts = parts;
        }
    }
}
