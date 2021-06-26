namespace SharedTrip.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class Trip
    {
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string StartPoint { get; set; }

        [Required]
        public string EndPoint { get; set; }

        public DateTime DepartureTime { get; set; } 

        public int Seats { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        public string ImagePath { get; set; }

        public ICollection<UserTrip> UserTrips { get; set; } = new List<UserTrip>();
    }
}
