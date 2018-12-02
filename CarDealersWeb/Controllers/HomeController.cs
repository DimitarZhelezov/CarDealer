using CarDealersWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CarDealersWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
