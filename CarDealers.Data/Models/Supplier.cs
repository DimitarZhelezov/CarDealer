using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarDealers.Data.Models
{
    public class Supplier
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public bool IsImporter { get; set; }

        public List<Part> Parts { get; set; } = new List<Part>();
    }
}
