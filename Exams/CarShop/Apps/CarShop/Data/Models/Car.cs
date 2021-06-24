namespace CarShop.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Car
    {
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(20)]
        public string Model { get; set; }

        public int Year { get; set; }

        [Required]
        public string PictureUrl { get; set; }

        [Required]
        [MaxLength(8)]
        public string PlateNumber { get; set; }

        public string OwnerId { get; set; }
        public User Owner { get; set; }

        public IEnumerable<Issue> Issues { get; set; } = new HashSet<Issue>();
    }
}
