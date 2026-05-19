using System.ComponentModel.DataAnnotations;

namespace ProcurmentProjectView.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please Enter Email")]
        public string UserEmail { get; set; } = default!;
        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; } = default!;
    }
}
