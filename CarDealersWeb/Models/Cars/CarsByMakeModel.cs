using CarDealer.Services.Models.Cars;
using System.Collections.Generic;

namespace CarDealersWeb.Models.Cars
{
    public class CarsByMakeModel
    {
        public string Make { get; set; }

        public IEnumerable<CarModel> Cars { get; set; }
    }
}
