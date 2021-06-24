namespace Git.Controllers
{
    using Git.Data;
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

        public HttpResponse All() => View();

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

                return Redirect("/Commits/All");
            }

            return Error(sb.ToString());
        }
    }
}
