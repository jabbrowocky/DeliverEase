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
        public int CustomerId { get; set; }
        public bool IsDelivered { get; set; }
        public bool IsAccepted { get; set; }
        public bool IsComplete { get; set; }

    }
}