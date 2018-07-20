using System;

namespace RentalService.DAL.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public int Note { get; set; }
        public int AccommodationId { get; set; }
    }
}
