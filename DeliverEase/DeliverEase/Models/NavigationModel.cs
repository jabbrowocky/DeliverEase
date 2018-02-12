using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeliverEase.Models
{
    public class NavigationModel
    {
        public string CurrentLocation { get; set; }
        public DeliveryDriver Driver { get; set; }
        public ToDeliver Delivery { get; set; }
    }
}