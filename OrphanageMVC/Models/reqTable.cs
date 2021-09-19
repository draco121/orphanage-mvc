using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrphanageMVC.Models
{
    public class reqTable
    {
        public string Id { get; set; }
        public Nullable<decimal> amount { get; set; }
        public string description { get; set; }
        public string status { get; set; }
        public System.DateTime date { get; set; }
        public int oId { get; set; }
        public Nullable<decimal> Deposited { get; set; }

    }
}