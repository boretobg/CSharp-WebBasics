namespace Andreys.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class User
    {
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [MaxLength(DefaultMaxLength)]
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public string Email { get; set; }
    }
}
