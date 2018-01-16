using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeliverEase.Models
{
    public class CustomerViewModel
    {
        Menu selectedMenu { get; set; }
        Customer customer { get; set; }
        Order order { get; set; }
    }
}