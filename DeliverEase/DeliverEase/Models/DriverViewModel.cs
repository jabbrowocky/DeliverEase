using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeliverEase.Models
{
    public class DriverViewModel
    {
        public DeliveryDriver Driver { get; set; }
        Order Order { get; set; }
    }
}