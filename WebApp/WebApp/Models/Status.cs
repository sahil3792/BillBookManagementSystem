﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Status
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Invoiceid { get; set; } // Auto-incrementing ID

        [Required]
        [StringLength(100)]
        public string InvoiceStatus { get; set; }
    }
}
