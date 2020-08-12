using LiteDB;
using System;

namespace MiniatureOrderManagementTool.Models
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

        public Order()
        {
        }

        public Order(Dtos.Order order)
        {
            this.ID = order.ID;
            this.ObjectID = order.ObjectID;
            this.IsFinished = order.IsFinished;
            this.Name = order.Name;
            this.CreatedAt = order.CreatedAt;
            this.ModifiedAt = order.ModifiedAt;
            this.Customer = order.Customer;
            this.Price = order.Price;
            this.Discount = order.Discount;
            this.Deadline = order.Deadline;
            this.Description = order.Description;
            this.TimeSpent = order.TimeSpent;

            var parts = new Part[order.Parts.Length];

            for (int i = 0; i < order.Parts.Length; i++)
            {
                parts[i] = new Part(order.Parts[i]);
            }

            this.Parts = parts;
        }
    }
}
