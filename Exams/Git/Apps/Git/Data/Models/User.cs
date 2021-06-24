namespace Git.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class User
    {
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(UserDefaultMaxLength)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [MaxLength(UserDefaultMaxLength)]
        public string Password { get; set; }

        IEnumerable<Repository> Repositories { get; set; } = new HashSet<Repository>();

        IEnumerable<Commit> Commits { get; set; } = new HashSet<Commit>();
    }
}
