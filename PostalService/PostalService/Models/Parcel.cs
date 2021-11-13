namespace PostalService.Models
{
    public class Parcel
    {
        public int Id { get; set; }
        public decimal Weight { get; set; }
        public int PhoneNumber { get; set; }
        public string Text { get; set; }
        public int? PostId { get; set; }
        public Post Post { get; set; }


    }
}
