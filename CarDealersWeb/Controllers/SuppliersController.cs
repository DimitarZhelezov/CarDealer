using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealer.Services.Abstractions;
using CarDealer.Services.Models;
using CarDealer.Services.Models.Enums;
using CarDealersWeb.Models.Suppliers;
using Microsoft.AspNetCore.Mvc;

namespace CarDealersWeb.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly ISupplierService supplierService;

        public SuppliersController(ISupplierService supplierService)
        {
            this.supplierService = supplierService;
        }

        [Route("suppliers/{a}")]
        public IActionResult Suppliers(string a)
        {
            IsImporter isLocal = a.ToLower() == "local"
                ? IsImporter.local
                : IsImporter.importer;


            var suppliers = this.supplierService.Suppliers(isLocal);

            return View(new SuppliersModel
            {
                Suppliers = suppliers,
                IsImporter = isLocal
            });
        }
    }
}