using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OrphanageMVC.Models
{
    public class OrphanageRegistrationView
    {
        public int oId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "this field is required")]
        [DisplayName("Orphanage Name")]
        public string oName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "this field is required")]
        [DisplayName("Registration Id")]
        public string oRegistrationNum { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "this field is required")]
        [DisplayName("Line 1")]
        public string addressLine1 { get; set; }
        [DisplayName("Line 2")]
        public string addressLine2 { get; set; }
        [DisplayName("Landmark")]
        public string landmark { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "this field is required")]
        [DisplayName("City")]
        public string city { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "this field is required")]
        [DisplayName("State")]
        public string state { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "this field is required")]
        [DisplayName("Country")]
        public string country { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "this field is required")]
        [DisplayName("Pincode")]
        public string pincode { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "this field is required")]
        [DisplayName("Contact Number")]
        public string phoneNum { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "this field is required")]
        [DisplayName("Password")]
        public string Password { get; set; }
    }
    // public string password { get { return password; } set { password = Common.PassEnDt.Encrypt(value); } }


}