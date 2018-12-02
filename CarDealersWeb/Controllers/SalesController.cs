using CarDealer.Services.Abstractions;
using CarDealersWeb.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace CarDealersWeb.Controllers
{
    public class SalesController : Controller
    {
        private readonly ISaleService saleService;

        public SalesController(ISaleService saleService)
        {
            this.saleService = saleService;
        }

        [Route("Sales")]
        public IActionResult All()
        {
            return View(this.saleService.All());
        }
        [Route("Sales/{Id}")]
        public IActionResult Details(int id)
        {
            return this.ViewOrNotFound(this.saleService.Details(id));
        }
    }
}
