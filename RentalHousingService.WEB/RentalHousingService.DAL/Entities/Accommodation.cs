namespace RentalService.DAL.Models
{
    public class Accommodation
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string Location { get; set; }
        public double Price { get; set; }
        public int AgeLimit { get; set; }
        public int Capacity { get; set; }
        public bool Animals { get; set; }
        public string Description { get; set; }
        public int Category { get; set; }

    }
}
