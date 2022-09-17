

#nullable disable

namespace ResturantAPI.Models
{
    public partial class Customerorder
    {
        public int Id { get; set; }
        public int MealId { get; set; }
        public int CustomerId { get; set; }
        public int OrderQuantity { get; set; }
        public bool Archived { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Resturantmenu Meal { get; set; }

    }
}
