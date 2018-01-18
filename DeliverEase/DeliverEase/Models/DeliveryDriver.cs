using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DeliverEase.Models
{
    public class DeliveryDriver
    {
        [Key]
        public int DriverId { get; set; }
        [Display(Name ="First Name")]
        public string DriverFirstName { get; set; }
        [Display(Name = "Last Name")]
        public string DriverLastName { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
        public bool HasDelivery { get; set; } = false;

    }
}