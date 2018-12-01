using CarDealer.Services.Models;
using CarDealer.Services.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealersWeb.Models.Suppliers
{
    public class SuppliersModel
    {
        public IEnumerable<SupplierModel> Suppliers { get; set; }

        public IsImporter IsImporter { get; set; }
    }
}