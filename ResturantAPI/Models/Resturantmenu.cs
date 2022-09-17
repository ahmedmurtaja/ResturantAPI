using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ResturantAPI.Models
{
    public partial class Resturantmenu
    {
        public int Id { get; set; }
        public string MealName { get; set; }
        public double PriceInNis { get; set; }
        public double PriceInUsd { get; set; }
        public int Quantity { get; set; }
        public bool Archived { get; set; }
        [Timestamp]
        public DateTime CreatedDateUTC { get; set; }
        [Timestamp]
        public DateTime UpdatedDateUTC { get; set; }
        public int ResturantId { get; set; }

        public virtual Resturant Resturant { get; set; }
    }
}
