namespace Andreys.Services
{
    using Andreys.ViewModels.Users;
    using System.Collections.Generic;

    public interface IValidator
    {
        ICollection<string> UserRegisterValidation(UserRegisterViewModel model);
        ICollection<string> UserLoginValidation(UserLoginViewModel model);
    }
}
