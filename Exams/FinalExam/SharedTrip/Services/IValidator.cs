namespace SharedTrip.Services
{
    using SharedTrip.ViewModels.Trips;
    using SharedTrip.ViewModels.Users;
    using System.Collections.Generic;

    public interface IValidator
    {
        IEnumerable<string> ValidateRegistration(RegisterViewModel model);

        IEnumerable<string> ValidateLogin(LoginViewModel model);

        IEnumerable<string> ValidateTrip(AddViewModel model);

    }
}
