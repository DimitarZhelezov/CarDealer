using CarDealer.Services.Models.Sales;
using System.Collections.Generic;

namespace CarDealer.Services.Abstractions
{
    public interface ISaleService
    {
        IEnumerable<SaleListModel> All();

        SaleDetailsModel Details(int id);
    }
}
