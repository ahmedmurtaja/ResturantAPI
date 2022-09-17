namespace ResturantAPI.Models
{
    #nullable enable
    public class CsvView
    {
        public string? RestaurantName { get; set; }
        public double? NumberOfOrderedCustomer { get; set; }
        public double? ProfitInUsd { get; set; }
        public double? ProfitInNis { get; set; }
        public string? TheBestSellingMeal { get; set; }
        public string? MostPurchasedCustomer { get; set; }
    }
}
