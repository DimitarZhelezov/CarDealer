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
            IsImporter isLocal = new IsImporter();

            if (a.ToLower() == "all" || a.ToLower() == "suppliers")
            {
                isLocal = IsImporter.all;
            }
            if (a.ToLower() == "local")
            {
                isLocal = IsImporter.local;
            }
            if (a.ToLower() == "importer")
            {
                isLocal = IsImporter.importer;
            }

            switch (a.ToLower())
            {
                case "all":
                    isLocal = IsImporter.all;
                    break;
                case "suppliers":
                    isLocal = IsImporter.all;
                    break;
                case "local":
                    isLocal = IsImporter.local;
                    break;
                case "importer":
                    isLocal = IsImporter.importer;
                    break;
                default:
                    break;
            }

            var suppliers = this.supplierService.Suppliers(isLocal);

            return View(new SuppliersModel
            {
                Suppliers = suppliers,
                IsImporter = isLocal
            });
        }
    }
}