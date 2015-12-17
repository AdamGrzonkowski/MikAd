using System;
using System.Collections.Generic;

namespace Shop.Model.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int PaymentId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime SendDate { get; set; }
        public bool IsFinished { get; set; }
        public bool IsReadyToSend { get; set; }
        public bool IsSent { get; set; }
        public string Notes { get; set; }

        public Payment Payment { get; set; }
        public User User { get; set; }
        public virtual ICollection<Detail> Details { get; set; }
    }
}