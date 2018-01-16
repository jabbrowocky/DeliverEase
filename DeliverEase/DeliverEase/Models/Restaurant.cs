using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DeliverEase.Models
{
    public class Restaurant
    {
        [Key]
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public string RestaurantAddress { get; set; }
        public string UserId { get; set; }
        [ForeignKey ("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}