using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeliverEase.Models
{
    public class OrderViewModel
    {
        public Customer Customer { get; set; }
        public Order CustomerOrder { get; set;}
        public IEnumerable <Menu> MenuSelection { get; set; }
    }
}