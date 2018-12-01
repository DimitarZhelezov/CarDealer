using CarDealer.Services.Abstractions;
using CarDealer.Services.Models.Cars;
using CarDealersWeb.Data;
using System.Collections.Generic;
using System.Linq;

namespace CarDealer.Services
{
    public class CarService : ICarService
    {
        private readonly CarDealersDbContext dbContext;

        public CarService(CarDealersDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public IEnumerable<CarModel> ByMake(string make)
        {
            if (make == "ByMake")
            {
                return this.dbContext
                    .Cars
                    .Select(c => new CarModel
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TravellDistance = c.TravelledDistance
                    }).ToList();
            }
            else
                return this.dbContext
                    .Cars
                    .Where(c => c.Make.ToLower() == make.ToLower())
                    .OrderBy(c => c.Model)
                    .ThenBy(c => c.TravelledDistance)
                    .Select(c => new CarModel
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TravellDistance = c.TravelledDistance
                    }).ToList();
        }

        public IEnumerable<CarWithPartsModel> WithParts()
             => this
            .dbContext
            .Cars
            .Select(c => new CarWithPartsModel
            {
                Make = c.Make,
                Model = c.Model,
                TravellDistance = c.TravelledDistance,
                Parts = c.Parts.Select(p => new PartModel
                {
                    Name = p.Part.Name,
                    Price = p.Part.Price
                })
            })
            .ToList();
    }
}
