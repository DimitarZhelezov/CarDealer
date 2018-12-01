﻿using CarDealer.Services.Abstractions;
using CarDealer.Services.Models.Cars;
using CarDealer.Services.Models.Customers;
using CarDealer.Services.Models.Enums;
using CarDealersWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarDealer.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CarDealersDbContext carDealersDbContext;

        public CustomerService(CarDealersDbContext carDealersDbContext)
        {
            this.carDealersDbContext = carDealersDbContext;
        }

        public IEnumerable<CustomerModel> OrderedCustomers(OrderDirection order)
        {
            var customerQuery = this.carDealersDbContext.Customers.AsQueryable();

            switch (order)
            {
                case OrderDirection.Ascending:
                    customerQuery = customerQuery.OrderBy(c => c.BirthDay)
                        .ThenBy(c => c.IsYoungDriver);
                    break;
                case OrderDirection.Descending:

                    customerQuery = customerQuery.OrderByDescending(c => c.BirthDay)
                        .ThenBy(c => c.IsYoungDriver);
                    break;
                default:
                    throw new InvalidOperationException("Invalid order direction");
            }
            return customerQuery
                .Select(c => new CustomerModel { Name = c.Name, BirthDay = c.BirthDay, IsYoungDriver = c.IsYoungDriver})
                .ToList();
        }

        public CustomerTotalSalesModel TotalSalesById(int id)
        {
            return this.carDealersDbContext
                .Customers
                .Where(c => c.Id == id)
                .Select(c => new CustomerTotalSalesModel
                {
                    Name = c.Name, 
                    IsYoungDriver = c.IsYoungDriver,
                    BoughtCars = c.Sales.Select( s => new CarPriceModel
                    { 
                        Price = s.Car.Parts.Sum(p => p.Part.Price),
                        Discount = s.Discount
                    })
                })
                .FirstOrDefault();
        }
    }
}
