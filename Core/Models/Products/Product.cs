using System;

namespace Core.Models.Products
{
    public class Product
    {
        public int ProductId { get; set; }

        public double Price { get; set; }

        public string Name { get; set; }

        public double Amount { get; set; }

        public DateTime Date { get; set; }
    }
}