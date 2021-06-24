namespace CarShop.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Issue
    {
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string Description { get; set; }

        public bool IsFixed { get; set; }

        public string CarId { get; set; }
        public Car Car { get; set; }
    }
}
