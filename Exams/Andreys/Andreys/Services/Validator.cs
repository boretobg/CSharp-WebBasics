namespace Andreys.Services
{
    using Andreys.ViewModels.Users;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using static Data.DataConstants;

    public class Validator : IValidator
    {
        public ICollection<string> UserLoginValidation(UserLoginViewModel model)
        {
            var errors = new List<string>();

            if (model.Username.Length < DefaultMinLength || model.Username.Length >= DefaultMaxLength)
            {
                errors.Add($"Username should be between {DefaultMinLength} and {DefaultMaxLength} characters.");
            }
            if (model.Password.Length < PasswordMinLength || model.Password.Length >= PasswordMaxLength)
            {
                errors.Add($"Password should be between {PasswordMinLength} and {PasswordMaxLength} characters.");
            }

            return errors;
        }

        public ICollection<string> UserRegisterValidation(UserRegisterViewModel model)
        {
            var errors = new List<string>();

            if (model.Username.Length < DefaultMinLength || model.Username.Length >= DefaultMaxLength)
            {
                errors.Add($"Username should be between {DefaultMinLength} and {DefaultMaxLength} characters.");
            }
            if (model.Password.Length < PasswordMinLength || model.Password.Length >= PasswordMaxLength)
            {
                errors.Add($"Password should be between {PasswordMinLength} and {PasswordMaxLength} characters.");
            }
            if (model.Password != model.ConfirmPassword)
            {
                errors.Add("Passwords should be identical.");
            }
            if (Regex.IsMatch(model.Email, @" ^ ([\w\.\-] +)@([\w\-] +)((\.(\w){ 2,3})+)$"))
            {
                errors.Add("Email is not valid.");
            }
            return errors;
        }
    }
}
