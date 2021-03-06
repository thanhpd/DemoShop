﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingTech.DAL
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ProductId { get; set; }

        public string ProductCode { get; set; }

        public string Name { get; set; }

        public decimal ListPrice { get; set; }

        public decimal DiscountPercent { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public Category Category { get; set; }
    }
}