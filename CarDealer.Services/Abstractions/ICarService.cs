using CarDealer.Services.Models.Cars;
using System.Collections.Generic;

namespace CarDealer.Services.Abstractions
{
    public interface ICarService
    {
        IEnumerable<CarModel> ByMake(string make);

        IEnumerable<CarWithPartsModel> WithParts(); 
    }
}
