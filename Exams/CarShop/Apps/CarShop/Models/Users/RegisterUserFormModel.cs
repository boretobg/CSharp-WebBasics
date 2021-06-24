namespace CarShop.Models.Users
{
    public class RegisterUserFormModel
    {
        public string Username { get; set; } //TODO: change them to init
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string UserType { get; set; }
    }
}
