using System.Collections.Generic;
using System.Linq;
using CarDealer.Services.Abstractions;
using CarDealer.Services.Models.Sales;
using CarDealersWeb.Data;
using CarDealer.Services.Models.Cars;

namespace CarDealer.Services.Implementations
{
    public class SaleService : ISaleService
    {
        private readonly CarDealersDbContext dbContext;

        public SaleService(CarDealersDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public IEnumerable<SaleListModel> All()
        {
            return this.dbContext.Sales
                .Select(s => new SaleListModel
                {
                    Id= s.Id,
                    CustomerName = s.Customer.Name,
                    Discount = s.Discount,
                    IsYoungDriver = s.Customer.IsYoungDriver,
                    Price = s.Car.Parts.Sum(p => p.Part.Price)
                })
                .ToList();
        }

        public SaleDetailsModel Details(int id)
        {
            return this.dbContext
                       .Sales
                       .Where(s => s.Id == id)
                       .Select(s => new SaleDetailsModel
                       {
                           Id = s.Id,
                           CustomerName = s.Customer.Name,
                           Discount = s.Discount,
                           IsYoungDriver = s.Customer.IsYoungDriver,
                           Price = s.Car.Parts.Sum(p => p.Part.Price),
                           Car = new CarModel
                           {
                               Make = s.Car.Make,
                               Model = s.Car.Model,
                               TravellDistance = s.Car.TravelledDistance
                           }
                       })
                       .FirstOrDefault();
        }
    }
}
