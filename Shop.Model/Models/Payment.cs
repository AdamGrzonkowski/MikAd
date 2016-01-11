using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Shop.Model.Models
{
    [DataContract]
    public class Payment : BaseEntity
    {

        [DataMember]
        public int OrderId { get; set; }

        [Display(Name = "Data zapłaty")]
        [DataMember]
        public DateTime Date { get; set; }

        [Display(Name = "Kwota zapłaty")]
        [DataMember]
        public Decimal Amount { get; set; }

        public Order Order { get; set; }
    }
}