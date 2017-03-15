using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StateHandling.Models
{
    public class SettingsCreateVM
    {
        [Display(Name = "Support E-mail")]
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }

        [Display(Name = "Company Name")]
        [Required(ErrorMessage = "Company name is required.")]
        public string CompanyName { get; set; }
    }
}
