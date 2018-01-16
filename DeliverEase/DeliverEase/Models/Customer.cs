using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DeliverEase.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
        [Display(Name ="First Name:")]
        public string CustomerFirstName { get; set; }
        [Display(Name ="Last Name:")]
        public string CustomerLastName { get; set; }
        [Display(Name = "Delivery Address")]
        public string CustomerAdress { get; set; }
        

    }
}