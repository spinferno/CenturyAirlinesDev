using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CenturyAirlines.Models
{
    public class LoginModel
    {
        [Display(Name = "Username")]
        [Required]
        public string Login { get; set; }

        [Display(Name = "Password")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}