using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitectureMvc.API.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email is requered")]
        [EmailAddress(ErrorMessage = "Invalid format email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is requered")]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 4)]
        public string Password { get; set; }
    }
}
