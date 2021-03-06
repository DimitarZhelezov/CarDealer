﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarDealers.Data.Models
{
    public class Part
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public int SupplierId { get; set; }

        public Supplier Supplier { get; set; }

        public List<PartCar> Cars { get; set; } = new List<PartCar>();
    }
}
