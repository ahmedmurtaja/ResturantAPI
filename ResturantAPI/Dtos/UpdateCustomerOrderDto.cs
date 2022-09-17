namespace ResturantAPI.Dtos
{
    public class UpdateCustomerOrderDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int MealId { get; set; }
        public int OrderQuantity { get; set; }
    }
}
