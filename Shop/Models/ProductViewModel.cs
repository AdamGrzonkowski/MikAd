﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Amount { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }
    }
}