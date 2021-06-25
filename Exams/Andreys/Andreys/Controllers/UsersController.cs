namespace Andreys.Controllers
{
    using Andreys.Data;
    using Andreys.Data.Models;
    using Andreys.Services;
    using Andreys.ViewModels.Users;
    using SIS.HTTP;
    using SIS.MvcFramework;
    using System.Linq;

    public class UsersController : Controller
    {
        private readonly IValidator validator;
        private readonly AndreysDbContext db;
        private readonly IPasswordHasher passwordHasher;

        public UsersController(IValidator validator, AndreysDbContext db, IPasswordHasher passwordHasher)
        {
            this.validator = validator;
            this.db = db;
            this.passwordHasher = passwordHasher;
        }

        public HttpResponse Register() => View();

        [HttpPost]
        public HttpResponse Register(UserRegisterViewModel model)
        {
            var errors = this.validator.UserRegisterValidation(model);

            if (db.Users.Any(u => u.Username == model.Username))
            {
                errors.Add($"Username already exists.");
            }
            if (db.Users.Any(u => u.Email == model.Email))
            {
                errors.Add("Email alredy exists.");
            }

            if (errors.Any())
            {
                return Redirect("/Users/Add");
            }

            var user = new User
            {
                Username = model.Username,
                Email = model.Email,
                Password = this.passwordHasher.HashPassword(model.Password)
            };

            db.Users.Add(user);
            db.SaveChanges();

            return Redirect("/Users/Login");
        }

        public HttpResponse Login() => View();

        [HttpPost]
        public HttpResponse Login(UserLoginViewModel model)
        {
            var errors = validator.UserLoginValidation(model);
            var hashedPassword = passwordHasher.HashPassword(model.Password);

            if (!db.Users.Any(u => u.Username == model.Username))
            {
                errors.Add("Username not registered.");
            }
            if (!db.Users.Any(u => u.Password == hashedPassword))
            {
                errors.Add("Wrong password.");
            }

            if (errors.Any())
            {
                return Redirect("/Users/Login");
            }

            var userId = db.Users
                .Where(u => u.Username == model.Username && u.Password == hashedPassword)
                .Select(u => u.Id)
                .FirstOrDefault();

            this.SignIn(userId);

            return Redirect("/Products/Details");
        }

        public HttpResponse Logout()
        {
            SignOut();

            return Redirect("/");
        }
    }
}
