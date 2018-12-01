using CarDealer.Services.Models;
using CarDealer.Services.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Services.Abstractions
{
    public interface ISupplierService
    {
        IEnumerable<SupplierModel> Suppliers(IsImporter isImporter);
    }
}
