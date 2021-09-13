using Newtonsoft.Json;
using OrphanageMVC.Models;
using System;
using System.Collections.Generic;
namespace OrphanageMVC.Models
{
    
    
    public class childRegisteration
    {

        public int CId { get; set; }
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
