﻿using System;
using System.Collections.Generic;

namespace Shop.Model.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime SendDate { get; set; }
        public bool IsPaid { get; set; }
        public bool IsSent { get; set; }

        public User User { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}