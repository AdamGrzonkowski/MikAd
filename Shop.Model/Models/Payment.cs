using System;
using System.Runtime.Serialization;

namespace Shop.Model.Models
{
    [DataContract]
    public class Payment : BaseEntity
    {

        [DataMember]
        public int OrderId { get; set; }

        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public Decimal Amount { get; set; }

        public Order Order { get; set; }
    }
}