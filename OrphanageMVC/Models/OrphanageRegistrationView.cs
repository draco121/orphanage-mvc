using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace OrphanageMVC.Models
{
    public class OrphanageRegistrationView
    {
        public int oId { get; set; }
        [DisplayName("Orphanage Name")]
        public string oName { get; set; }
        [DisplayName("Registration Number")]
        public string oRegistrationNum { get; set; }
        [DisplayName("Line1")]
        public string addressLine1 { get; set; }
        [DisplayName("Line2")]
        public string addressLine2 { get; set; }
        [DisplayName("Landmark")]
        public string landmark { get; set; }
        [DisplayName("City")]
        public string city { get; set; }
        [DisplayName("State")]
        public string state { get; set; }
        [DisplayName("Country")]
        public string country { get; set; }
        [DisplayName("Pincode")]
        public string pincode { get; set; }
        [DisplayName("Contact Number")]
        public string phoneNum { get; set; }
        [DisplayName("Password")]
        public string password { get; set; }
    }
}