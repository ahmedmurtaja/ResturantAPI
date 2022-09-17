using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ResturantAPI.Models
{
    public partial class Resturant
    {
        public Resturant()
        {
            Resturantmenus = new HashSet<Resturantmenu>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        [Timestamp]
        public DateTime CreatedDateUTC { get; set; }
        [Timestamp]
        public DateTime UpdatedDateUTC { get; set; }
        public bool Archived { get; set; }

        public virtual ICollection<Resturantmenu> Resturantmenus { get; set; }
    }
}
