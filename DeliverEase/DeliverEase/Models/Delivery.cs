using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DeliverEase.Models
{
    public class Delivery
    {
        [Key]
        public int Id { get;set;}
        public int CustomerId { get; set; }
        public int DriverId { get; set; }
        public bool IsDelivered { get; set; }
        
        
    }
}