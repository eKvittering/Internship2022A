using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CuSubs
{
    public class CustomersSubscriptions
    {
        [Key]
        public int CustomersCustomerId { get; set; }
        [Key]
        public int SubscriptionsSubcscriptionId { get; set; }

        public ICollection<Subscriptions> Subscriptions { get; set; }

        public ICollection<Customers> Customers { get; set; }
    }
}
