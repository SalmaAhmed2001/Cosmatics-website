﻿using EcommercePro.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommercePro.DTO
{
    public class ProductData
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The Name of Product is Reqiured")]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Discount { set; get; } = 0;
        [Required(ErrorMessage = "The Price of Product is Reqiured")]
        [ProductPrice]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "The Quantity of Product is Reqiured")]
        public int Quentity { get; set; }

        [Required(ErrorMessage = "The Category of Product is Reqiured")]
        public int CategoryId { get; set; }
        public List<string> ImageUrls { get; set; }

        public string ImageUrl { get; set; } // Add this property



    }
}
