using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DeliverEase.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerAdress { get; set; }
        public List<string> Order { get; set; }

    }
}