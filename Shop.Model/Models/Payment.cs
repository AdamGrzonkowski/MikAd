using System;

namespace Shop.Model.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public DateTime Date { get; set; }
        public Decimal Amount { get; set; }

        public Order Order { get; set; }
    }
}