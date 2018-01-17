using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeliverEase.Models
{
    public class CustomerViewModel
    {
        public Restaurant RestaurantSelection { get; set; }
        public Menu SelectedMenu { get; set; }
        public Customer Customer { get; set; }
        public Order Order { get; set; }
    }
}