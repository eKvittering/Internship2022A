using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CuSubs
{
    public class Customers
    {
        [Key]
        public int CustomerId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string PostCode { get; set; }

        public string City { get; set; }

        public string Telephone { get; set; }

        
        public string PbsNr { get; set; }

        public string AftalenNr { get; set; }

        public string RegNr { get; set; }

        public string Balance { get; set; }

        public string AccNr { get; set; }

        public string CPR { get; set; }

        public ICollection<Subscriptions> Subscriptions { get; set; }

    }
}
