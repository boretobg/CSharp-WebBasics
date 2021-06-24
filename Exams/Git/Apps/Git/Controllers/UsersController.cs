namespace Git.Controllers
{
    using Git.Data;
    using Git.Data.Models;
    using Git.Services;
    using Git.ViewModels;
    using SUS.HTTP;
    using SUS.MvcFramework;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using static Git.Data.DataConstants;

    public class UsersController : Controller
    {
        //private readonly IValidator validator;
        private readonly ApplicationDbContext data;

        public UsersController(/*IValidator validator*/ ApplicationDbContext data)
        {
            this.data = data;
        }

        public HttpResponse Register() => View();

        [HttpPost]
        public HttpResponse Register(UserViewModel model)
        {
            var errors = new StringBuilder();

            if (model.Username.Length < UserUsernameMinLength || model.Username.Length > UserDefaultMaxLength)
            {
                errors.AppendLine($"Username must be between {UserUsernameMinLength} and {UserDefaultMaxLength} characters.");
            }
            if (!Regex.IsMatch(model.Email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                errors.AppendLine($"Email is not in the correct format");
            }
            if (model.Password.Length < UserPasswordMinLength || model.Password.Length > UserDefaultMaxLength)
            {
                errors.AppendLine($"Password must be between {UserPasswordMinLength} and {UserDefaultMaxLength} characters.");
            }
            if (model.Password != model.ConfirmPassword)
            {
                errors.AppendLine($"Passwords must match.");
            }

            //TODO: add checks for the username and email from the db

            if (string.IsNullOrWhiteSpace(errors.ToString()))
            {
                var user = new User
                {
                    Username = model.Username,
                    Email = model.Email,
                    Password = model.Password
                };

                data.Users.Add(user);
                data.SaveChanges();

                return Redirect("/Users/Login");
            }

            return Error(errors.ToString()) ;
        }

        public HttpResponse Login() => View();

        [HttpPost]
        public HttpResponse Login(UserViewModel model)
        {
            var user = data
                .Users
                .FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);

            if (user == null)
            {
                return Error("User does not exist.");
            }

            SignIn(user.Id);
            return Redirect("/Repositories/All");
        }

    }
}
