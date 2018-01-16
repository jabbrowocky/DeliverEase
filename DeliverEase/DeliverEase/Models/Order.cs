using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeliverEase.Models
{
    public class Order
    {
        public int CustomerId { get; set; }
        public List<string> OrderInfo { get; set; }
    }
}