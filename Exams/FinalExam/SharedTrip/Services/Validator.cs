namespace SharedTrip.Services
{
    using SharedTrip.ViewModels.Trips;
    using SharedTrip.ViewModels.Users;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using static Data.DataConstants;

    public class Validator : IValidator
    {
        public IEnumerable<string> ValidateLogin(LoginViewModel model)
        {
            var errors = new List<string>();

            if (model.Username.Length < UsernameMinLength || model.Username.Length > UsernameMaxLength)
            {
                errors.Add($"Username should be between {UsernameMinLength} and {UsernameMaxLength} characters.");   
            }
            if (model.Password.Length < PasswordMinLength || model.Password.Length > PasswordMaxLength)
            {
                errors.Add($"Password should be between {PasswordMinLength} and {PasswordMaxLength} characters.");
            }

            return errors;
        }

        public IEnumerable<string> ValidateRegistration(RegisterViewModel model)
        {
            var errors = new List<string>();

            if (model.Username.Length < UsernameMinLength || model.Username.Length > UsernameMaxLength)
            {
                errors.Add($"Username should be between {UsernameMinLength} and {UsernameMaxLength} characters.");
            }
            if (!Regex.IsMatch(model.Email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                errors.Add("Email is not in the correct format.");
            }
            if (model.Password.Length < PasswordMinLength || model.Password.Length > PasswordMaxLength)
            {
                errors.Add($"Password should be between {PasswordMinLength} and {PasswordMaxLength} characters.");
            }
            if (model.Password != model.ConfirmPassword)
            {
                errors.Add("Passwords should match.");
            }

            return errors;
        }

        public IEnumerable<string> ValidateTrip(AddViewModel model)
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(model.DepartureTime.ToString()) || model.DepartureTime.ToString() == "")
            {
                errors.Add("Date is not valid.");
            }
            if (model.Seats < SeatsMinValue || model.Seats > SeatsMaxValue)
            {
                errors.Add($"Seats can be between {SeatsMinValue} and {SeatsMaxValue}.");
            }
            if (model.Description.Length > DescriptionMaxLength)
            {
                errors.Add($"Description should be no more than {DescriptionMaxLength} characters.");
            }
            return errors;
        }
    }
}
