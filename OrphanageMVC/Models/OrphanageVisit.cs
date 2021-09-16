using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrphanageMVC.Models
{
    public class OrphanageVisit
    {
        public System.Guid aId { get; set; }
        public string aName { get; set; }
        public string aAddress { get; set; }
        public string aContactNumber { get; set; }
        public System.DateTime aCurrenntDate { get; set; }
        public string aScheduleDate { get; set; }
        public string aScheduleTime { get; set; }
        public int oId { get; set; }

        public virtual OrphanageRegistrationView orphanageRegistration1 { get; set; }
    }
}