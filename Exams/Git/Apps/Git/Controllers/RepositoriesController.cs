namespace Git.Controllers
{
    using Git.Data;
    using Git.Data.Models;
    using Git.ViewModels;
    using SUS.HTTP;
    using SUS.MvcFramework;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using static Git.Data.DataConstants;

    public class RepositoriesController : Controller
    {
        private readonly ApplicationDbContext data;

        public RepositoriesController(ApplicationDbContext data)
        {
            this.data = data;
        }

        public HttpResponse All()
        {
            var repos = this.data
                .Repositories
                .Where(x => x.IsPublic)
                .Select(x => new RepositoryListViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Owner = x.Owner.Username,
                    Commits = x.Commits.Count(),
                    CreatedOn = x.CreatedOn
                }).ToList();

            return View(repos);
        }


        public HttpResponse Create() => View();

        [HttpPost]
        public HttpResponse Create(RepositoryCreateViewModel model)
        {
            var sb = new StringBuilder();

            if (data.Repositories.Any(x => x.Name == model.Name))
            {
                sb.AppendLine($"Repository with that name already exists.");
            }
            if (model.Name.Length < RepositoryNameMinLength || model.Name.Length > RepositoryNameMaxLength)
            {
                sb.AppendLine($"Name must be between {RepositoryNameMinLength} and {RepositoryNameMaxLength} characters.");
            }

            if (string.IsNullOrWhiteSpace(sb.ToString()))
            {
                var repo = new Repository
                {
                    Name = model.Name,
                    IsPublic = model.RepositoryType == RepositoryPublicType,
                    OwnerId = this.GetUserId()
                };

                data.Repositories.Add(repo);
                data.SaveChanges();

                return Redirect("/Commits/All");
            }

            return Error(sb.ToString());
        }
    }
}
