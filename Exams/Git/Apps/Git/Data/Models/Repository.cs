namespace Git.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Repository
    {
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(RepositoryNameMaxLength)]
        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsPublic { get; set; }

        [Required]
        public string OwnerId { get; set; }
        public User Owner { get; set; }

        IEnumerable<Commit> Commits { get; set; } = new HashSet<Commit>();
    }
}
