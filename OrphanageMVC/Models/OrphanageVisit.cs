using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OrphanageMVC.Models
{
    public class OrphanageVisit
    {
        public System.Guid aId { get; set; }

        [DisplayName("Full Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "this field is required")]
        public string aName { get; set; }
        [DisplayName("Address")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "this field is required")]
        public string aAddress { get; set; }
        [DisplayName("Contact Number")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "this field is required")]
        public string aContactNumber { get; set; }
        public System.DateTime aCurrenntDate { get; set; }

        [DisplayName("Date of appointment")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "this field is required")]
        public string aScheduleDate { get; set; }
        [DisplayName("Time of appointment")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "this field is required")]
        public string aScheduleTime { get; set; }
        public int oId { get; set; }

        public virtual OrphanageRegistrationView orphanageRegistration1 { get; set; }
    }
}