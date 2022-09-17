namespace ResturantAPI.Dtos
{
    public class UpdateResturantMenuDto
    {
        public int Id { get; set; }
        public string MealName { get; set; }
        public double PriceInNis { get; set; }
        public int Quantity { get; set; }
        public int ResturantId { get; set; }
    }
}
