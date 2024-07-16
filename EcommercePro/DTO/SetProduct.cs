﻿using EcommercePro.Models;
using System.ComponentModel.DataAnnotations;

namespace EcommercePro.DTO
{
    public class SetProduct
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The Name of Product is Reqiured")]
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Discount { set; get; } = 0;
        [Required(ErrorMessage = "The Price of Product is Reqiured")]
        [ProductPrice]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "The Quantity of Product is Reqiured")]
        public int Quentity { get; set; }
        public List<IFormFile>? formFiles { get; set; }

        [Required(ErrorMessage = "The Category of Product is Reqiured")]
        public int CategoryId { get; set; }
        public string userid { set; get; }

    }
}
