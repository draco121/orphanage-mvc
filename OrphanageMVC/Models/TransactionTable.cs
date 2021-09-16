using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrphanageMVC.Models
{
    public class TransactionTable
    {
        public int tId { get; set; }
        public int oId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public decimal Amount { get; set; }

        public virtual OrphanageRegistrationView orphanageRegistration1 { get; set; }
    }
}