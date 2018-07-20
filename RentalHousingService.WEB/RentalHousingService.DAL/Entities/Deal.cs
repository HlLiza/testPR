using System;

namespace RentalService.DAL.Models
{
    public class Deal
    {
        public int Id { get; set; }
        public int AccommodationId { get; set; }
        public int TenantId { get; set; }
        public int OwnerId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateFinish { get; set; }
        public bool Confirmation { get; set; }

    }
}
