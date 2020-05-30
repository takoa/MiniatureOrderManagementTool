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
        public DateTime Deadline { get; set; }
        public Part[] Parts { get; set; }
        public string Description { get; set; }
        public decimal TimeSpent { get; set; }
    }
}