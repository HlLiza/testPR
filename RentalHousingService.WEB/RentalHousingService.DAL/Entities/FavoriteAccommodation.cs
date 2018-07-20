using System;

namespace RentalService.DAL.Models
{
    public class FavoriteAccommodation
    {
        public int Id { get; set; }
        public int AccommodationId { get; set; }
        public int UserId { get; set; }
    }
}
