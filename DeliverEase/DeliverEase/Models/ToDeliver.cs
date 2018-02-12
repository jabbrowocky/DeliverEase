using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DeliverEase.Models
{
    public class ToDeliver
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }
        [Display(Name = "Customer Address")]
        public string CustomerAddress { get; set; }
        public List <Order> Items { get; set; }
        [Display(Name = "Order Cost")]
        public decimal OrderCost { get; set; }       
        public int CustomerId { get; set; }
        public bool IsDelivered { get; set; }
        public bool IsAccepted { get; set; }
        public bool IsComplete { get; set; }
        public Restaurant Rest { get; set; }

    }
}