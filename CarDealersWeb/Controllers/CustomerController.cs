using CarDealer.Services.Abstractions;
using CarDealer.Services.Models.Enums;
using CarDealersWeb.Models.Customers;
using Microsoft.AspNetCore.Mvc;
using CarDealersWeb.Extensions;

namespace CarDealersWeb.Controllers
{

    [Route("customer")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [Route(nameof(Create))]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Route(nameof(Create))]
        public IActionResult Create(CreateCustomerModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            this.customerService.Create(
                model.Name,
                model.BirthDay,
                model.IsYoungDriver
                );

            return RedirectToAction(nameof(AllSorted));
        }

        [Route("{all}/{order}")]
        public IActionResult AllSorted(string order)
        {
            OrderDirection orderDirection = order.ToLower() == "descending"
                ? OrderDirection.Descending
                : OrderDirection.Ascending;

            var customers = this.customerService.OrderedCustomers(orderDirection);

            return View(new AllCustomersModel
            {
                Customers = customers,
                OrderDirection = orderDirection
            });
        }
        [Route("{id}")]
        public IActionResult TotalSales(int id)
        {
            return this.ViewOrNotFound(this.customerService.TotalSalesById(id));
        }

    }
}
