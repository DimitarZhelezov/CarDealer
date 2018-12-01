using Microsoft.AspNetCore.Mvc;
using CarDealer.Services;
using CarDealer.Services.Abstractions;
using CarDealersWeb.Models.Cars;

namespace CarDealersWeb.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarService cars;

        public CarsController(ICarService cars)
        {
            this.cars = cars;
        }
        [Route("cars/{make}")]
        public IActionResult ByMake(string make)
        {
            var cars = this.cars.ByMake(make);

            return View(new CarsByMakeModel
            {
                Make = make,
                Cars = cars
            });

        }
        [Route("cars/parts")]
        public IActionResult Parts()
        {
            return View(this.cars.WithParts());
        }
    }
}
