namespace AirBnbWAD.Models
{
    using Microsoft.AspNetCore.Mvc.ViewEngines;
    using Newtonsoft.Json.Linq;
    using System.Collections.Generic;

    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public ICollection<Property>? Properties { get; set; }
        public ICollection<Booking>? Bookings { get; set; }
        public ICollection<Review>? Reviews { get; set; }
    }
}
