namespace CarDealer.Services.Models.Sales
{
    using Models.Cars;

    public class SaleDetailsModel : SaleListModel
    {
        public CarModel Car { get; set; }
    }
}
