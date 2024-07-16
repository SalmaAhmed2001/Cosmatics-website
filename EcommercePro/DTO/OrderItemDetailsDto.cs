﻿namespace EcommercePro.DTO
{
    public class OrderItemDetailsDto
    {
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductDescription { get; set; }
    }
}