﻿using CarDealer.Services.Models.Customers;
using System.Collections.Generic;
using CarDealer.Services.Models.Enums;

namespace CarDealersWeb.Models.Customers
{
    public class AllCustomersModel
    {
        public IEnumerable<CustomerModel> Customers { get; set; }

        public OrderDirection OrderDirection { get; set; }
    }
}
