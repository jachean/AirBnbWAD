namespace AirBnbWAD.Models
{

    public class Image
    {
        public int ImageID { get; set; }
        public int PropertyID { get; set; }
        public string ImageURL { get; set; }

        public Property? Property { get; set; }
    }
}
