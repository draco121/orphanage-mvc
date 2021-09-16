using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OrphanageMVC.Models
{
    public class LoginModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "this field is required")]
        [DisplayName("registraion number")]
        public string oRegistrationNum { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "this field is required")]
        [DisplayName("Password")]
        public string Password { get; set; }
    }
}