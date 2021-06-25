namespace Andreys.Data.Models
{
    using Andreys.Data.Models.Enums;
    using System;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Product
    {
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [MaxLength(ProductNameMaxLength)]
        [Required]
        public string Name { get; set; }

        [MaxLength(DefaultMaxLength)]
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        [Required]
        public CategoryType Category { get; set; }

        [Required]
        public GenderType Gender { get; set; }
    }
}
