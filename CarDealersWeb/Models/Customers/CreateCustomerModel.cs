using System;
using System.ComponentModel.DataAnnotations;

namespace CarDealersWeb.Models.Customers
{
    public class CreateCustomerModel
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        public DateTime BirthDay { get; set; }  
        [Display (Name = "Young Driver")]
        public bool IsYoungDriver { get; set; }
    }
}
