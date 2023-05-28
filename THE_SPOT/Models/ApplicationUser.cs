using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace THE_SPOT.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "First name")]
        [Required(ErrorMessage = "Full name is required")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        [Required(ErrorMessage = "Full name is required")]
        public string LastName { get; set; }

    }
}
