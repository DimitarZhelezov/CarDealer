namespace CarDealersWeb.Controllers
{
    using CarDealer.Services.Abstractions;
    using CarDealer.Services.Models.Enums;
    using CarDealersWeb.Models.Customers;
    using Microsoft.AspNetCore.Mvc;

    [Route("customer")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [Route("{all}/{order}")]
        public IActionResult All(string order)
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
               =>this.View(this.customerService.TotalSalesById(id));

    }
}
