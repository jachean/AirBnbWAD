namespace AirBnbWAD.Models
{

    public class Review
    {
        public int ReviewID { get; set; }
        public int PropertyID { get; set; }
        public int UserID { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }

        public Property? Property { get; set; }
        public User? User { get; set; }
    }
}
