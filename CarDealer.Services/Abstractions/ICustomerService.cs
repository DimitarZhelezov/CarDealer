using CarDealer.Services.Models.Enums;
using CarDealer.Services.Models.Customers;
using System.Collections.Generic;
using System;

namespace CarDealer.Services.Abstractions
{ 
    public interface ICustomerService
    {
        IEnumerable<CustomerModel> OrderedCustomers(OrderDirection order);

        CustomerTotalSalesModel TotalSalesById(int id);

        void Create(string name, DateTime birthDay, bool IsYoungDriver);
    }
}
