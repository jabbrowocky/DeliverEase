﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DeliverEase.Models
{
    public class Menu
    {
        [Key]
        public int Id { get; set; }
        public string MenuItem { get; set; }
        public double ItemPrice { get; set; }
        public int RestaurantId {get;set;}
        [ForeignKey(name: "RestaurantId")]
        public Restaurant Restaurant { get;set;}

    }
}