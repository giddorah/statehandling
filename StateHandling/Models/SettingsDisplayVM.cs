using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StateHandling.Models
{
    public class SettingsDisplayVM
    {
        [Display(Name = "Support E-mail: ")]
        public string Email { get; set; }
        [Display(Name = "Company Name: ")]
        public string CompanyName { get; set; }

        public string Greeting { get; set; }
    }
}
