using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CuSubs
{
    public class Subscriptions
    {
        [Key]
        public int SubscriptionId { get; set; }

        public string SubscriptionName { get; set; }

        public string Rate { get; set; }

        public string RateNumbers { get; set; }

        public string PaymentType { get; set; }

        public ICollection<Customers> Customers { get; set; }
    }
}
