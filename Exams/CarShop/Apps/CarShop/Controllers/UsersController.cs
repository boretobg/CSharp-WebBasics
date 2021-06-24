namespace CarShop.Controllers
{
    using CarShop.Data;
    using CarShop.Data.Models;
    using CarShop.Models.Users;
    using SUS.HTTP;
    using SUS.MvcFramework;
    using System.Collections.Generic;
    using System.Text;

    public class UsersController : Controller
    {
        private readonly ApplicationDbContext data;

        public UsersController(ApplicationDbContext data)
        {
            this.data = data;
        }

        public HttpResponse Register() => View();

        [HttpPost]
        public HttpResponse Register(RegisterUserFormModel model)
        {
            var error = new StringBuilder();
            bool flag = false;

            if (model.Username.Length < 4 || model.Username.Length > 20)
            {
                flag = true;
                error.AppendLine($"Username length must be between 4 and 20 characters!");
            }
            //if (model.Email)
            //{

            //}
            if ((model.Password.Length < 5 || model.Password.Length > 20)
                || (model.ConfirmPassword.Length < 5 || model.ConfirmPassword.Length > 20))
            {
                flag = true;
                error.AppendLine($"Password length must be between 5 and 20 characters!");
            }
            if (model.Password != model.ConfirmPassword)
            {
                flag = true;
                error.AppendLine($"Passwords are not the same!");
            }

            if (flag)
            {
                return Error(error.ToString().Trim());
            }

            var user = new User
            {
                Username = model.Username,
                Email = model.Email,
                Password = model.Password,
                //IsMechanic = model.UserType
            };

            return Redirect("/Users/Login");
        }

        public HttpResponse Login() => View();

        [HttpPost]
        public HttpResponse Login(LoginUserFormModel model)
        {

            return Redirect("/Cars/All");
        }
    }
}
