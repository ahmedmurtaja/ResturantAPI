using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ResturantAPI.Models
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Timestamp]
        public DateTime CreatedDateUTC { get; set; }
        [Timestamp]
        public DateTime UpdatedDateUTC { get; set; }
        public bool Archived { get; set; }
    }
}
