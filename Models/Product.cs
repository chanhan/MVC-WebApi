﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    using System.ComponentModel.DataAnnotations;
    public class Product
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        public string ProductName { get; set; }

        public string Category { get; set; }

        public decimal Price { get; set; }

        public decimal ActualCost { get; set; }
    }
}