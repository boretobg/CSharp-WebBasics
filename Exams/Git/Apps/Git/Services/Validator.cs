
namespace Git.Services
{
    using Git.ViewModels;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    using static Git.Data.DataConstants;

    public class Validator : IValidator
    {
        public string RegisterValidation(UserViewModel model)
        {
            var sb = new StringBuilder();

            if (model.Username.Length < UserUsernameMinLength || model.Username.Length > UserDefaultMaxLength)
            {
                sb.AppendLine($"Username must be between {UserUsernameMinLength} and {UserDefaultMaxLength} characters.");
            }
            if (!Regex.IsMatch(model.Email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                sb.AppendLine($"Email is not in the correct format!");
            }
            if (model.Password.Length < UserPasswordMinLength || model.Password.Length > UserDefaultMaxLength)
            {
                sb.AppendLine($"Password must be between {UserPasswordMinLength} and {UserDefaultMaxLength} characters.");
            }

            return sb.ToString().Trim();
        }
    }
}
