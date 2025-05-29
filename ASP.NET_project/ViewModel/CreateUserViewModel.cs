using System.ComponentModel.DataAnnotations;

namespace ASP.NET_project.ViewModel
{
    public class CreateUserViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Hasło musi mieć co najmniej 6 znaków.")]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
