using System.ComponentModel.DataAnnotations;

namespace LibraryWithAttributesConsoleApplication
{
    public class User
    {
        [Required]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Login must have at least 1 symbol and 20 symbol max.")]
        public string Login { get; private set; }
        [Required]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Password must have at least 1 symbol and 20 symbol max.")]
        public string Password { get; private set; }

        public User(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}
