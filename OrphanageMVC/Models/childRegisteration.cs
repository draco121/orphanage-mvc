//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OrphanageMVC.Models
{
    using Newtonsoft.Json;
    using OrphanageMVC.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class childRegisteration
    {

        public int CId { get; set; }

        [DisplayName(" First Name ")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }
        public string Gender { get; set; }
        //[JsonIgnore]
        public int oId { get; set; }
        public string Nationality { get; set; }
        public Nullable<System.DateTime> DateAdmitted { get; set; }

        //[JsonIgnore]
        public virtual OrphanageRegistrationView orphanageRegistration1 { get; set; }
    }
}
