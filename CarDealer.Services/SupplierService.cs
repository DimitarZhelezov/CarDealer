using CarDealer.Services.Abstractions;
using CarDealer.Services.Models;
using CarDealer.Services.Models.Enums;
using CarDealersWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarDealer.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly CarDealersDbContext db;

        public SupplierService(CarDealersDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<SupplierModel> Suppliers(IsImporter isImporter)
        {
            var suppliers = this.db.Suppliers.AsQueryable();

            switch (isImporter)
            {
                case IsImporter.local:
                    suppliers = suppliers.Select(c => c)
                        .Where(s => s.IsImporter == false)
                        .AsQueryable();
                    break;
                case IsImporter.importer:
                    suppliers = suppliers.Select(c => c)
                        .Where(s => s.IsImporter == true)
                        .AsQueryable();
                    break;
                default:
                    throw new InvalidOperationException();
            }

            return suppliers
                .Select(s =>
                new SupplierModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    NumberOfParts = s.Parts.Count
                })
                .ToList();
        }
    }
}
