﻿using System;

namespace Git.ViewModels
{
    public class RepositoryListViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Owner { get; set; }

        public DateTime CreatedOn { get; set; }

        public int Commits { get; set; }
    }
}
