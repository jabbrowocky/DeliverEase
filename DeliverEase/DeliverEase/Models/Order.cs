using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DeliverEase.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer customer { get; set; }        
        public List<Menu> OrderInfo { get; set; }
        public Restaurant Selection { get; set; }
        [Display(Name = "Item Name:")]
        public string OrderDetails { get; set; }
        public Menu menuItemId { get; set; }
        [Display(Name = "Item Cost:")]
        public double OrderCost { get; set; }
        public bool IsAccepted { get; set; } = false;
        public bool IsSubmitted { get; set; } = false;        
        public int DeliveryId { get; set; }
    }
}