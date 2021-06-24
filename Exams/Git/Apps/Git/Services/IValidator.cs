namespace Git.Services
{
    using Git.ViewModels;
    using System.Collections.Generic;

    public interface IValidator
    {
        string RegisterValidation(UserViewModel model);
    }
}
