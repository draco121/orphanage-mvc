using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrphanageMVC.Models
{
    public class reqTable
    {
        public int rId { get; set; }
        public string requirementName { get; set; }
        public string requirementStatus { get; set; }
        public int oId { get; set; }
        [JsonIgnore]
        public virtual OrphanageRegistrationView orphanageRegistration1 { get; set; }
    }
}