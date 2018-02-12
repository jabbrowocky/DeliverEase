using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeliverEase.Models
{
    public class PaymentModel
    {
        public Customer Cust { get; set; }
        public ToDeliver Del { get; set; }

    }
}