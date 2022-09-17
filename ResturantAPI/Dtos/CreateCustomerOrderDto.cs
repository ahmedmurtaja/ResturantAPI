namespace ResturantAPI.Dtos
{
    public class CreateCustomerOrderDto
    {
        public int MealId { get; set; }
        public int CustomerId { get; set; }
        public int OrderQuantity { get; set; }
    }
}
