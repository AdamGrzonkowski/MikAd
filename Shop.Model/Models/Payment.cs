using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Shop.Model.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int TransactionId { get; set; }
        public decimal ToPay { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}