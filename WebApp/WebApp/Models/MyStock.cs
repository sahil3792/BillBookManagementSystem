﻿using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class MyStock
    {
        // Can't share these as api only expects rest 4 
        [Key]
        public int? StockId { get; set; } = 0; // no use for this
        public int? PurchaseOrderId { get; set; } = 0;

        public string? ItemName { get; set; }
        public string? ItemCode { get; set; }

        //public string? HSNCode { get; set; }
        public string? Category { get; set; }
        public double? Quantity { get; set; }
    }
}
