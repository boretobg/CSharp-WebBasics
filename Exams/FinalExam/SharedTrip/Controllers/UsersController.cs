namespace SharedTrip.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SharedTrip.Data;
    using SharedTrip.Models;
    using SharedTrip.Services;
    using SharedTrip.ViewModels.Users;
    using System.Collections.Generic;
    using System.Linq;

    public class UsersController : Controller
    {
        private readonly IValidator validator;
        private readonly ApplicationDbContext db;
        private readonly IPasswordHasher passwordHasher;

        public UsersController(
            IValidator validator,
            ApplicationDbContext db,
            IPasswordHasher passwordHasher)
        {
            this.validator = validator;
            this.db = db;
            this.passwordHasher = passwordHasher;
        }

        public HttpResponse Register() => View();

        [HttpPost]
        public HttpResponse Register(RegisterViewModel model)
        {
            //i think the error page is not needed (no info in the description)
            var errors = this.validator.ValidateRegistration(model).ToList();

            if (db.Users.Any(u => u.Username == model.Username))
            {
                errors.Add("Username already exists.");
            }
            if (db.Users.Any(u => u.Email == model.Email))
            {
                errors.Add("Email already exists.");
            }

            if (errors.Any())
            {
                return Error(errors);
                //return Redirect("/Users/Register");
            }

            var user = new User
            {
                Username = model.Username,
                Email = model.Email,
                Password = this.passwordHasher.Hash(model.Password)
            };

            db.Users.Add(user);
            db.SaveChanges();

            return Redirect("/Users/Login");
        }

        public HttpResponse Login() => View();

        [HttpPost]
        public HttpResponse Login(LoginViewModel model)
        {
            var hashedPassword = this.passwordHasher.Hash(model.Password);

            var errors = this.validator.ValidateLogin(model).ToList();

            var userId = db.Users
                .Where(x => x.Username == model.Username && x.Password == hashedPassword)
                .Select(u => u.Id)
                .FirstOrDefault();

            if (userId == null)
            {
                errors.Add("User is not valid.");
            }

            if (errors.Any())
            {
                // return Error(errors);
                return Redirect("/Users/Login");
            }

            this.SignIn(userId);

            return Redirect("/Trips/All");
        }

        public HttpResponse Logout()
        {
            this.SignOut();

            return Redirect("/");
        }
    }
}
