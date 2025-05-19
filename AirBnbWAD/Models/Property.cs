namespace AirBnbWAD.Models
{

    using Microsoft.AspNetCore.Mvc.ViewEngines;

    public class Property
    {
        public int PropertyID { get; set; }
        public int OwnerID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public decimal Price { get; set; }

        public User? Owner { get; set; }
        public ICollection<Booking>? Bookings { get; set; }
        public ICollection<Review>? Reviews { get; set; }
        public ICollection<Image>? Images { get; set; }
    }
}