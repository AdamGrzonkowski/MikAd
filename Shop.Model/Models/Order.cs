using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Shop.Model.Models
{
    [DataContract]
    public class Order
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string UserId { get; set; }

        [DataMember]
        public int PaymentId { get; set; }

        [DataMember]
        public decimal TotalPrice { get; set; }

        [DataMember]
        public DateTime OrderDate { get; set; }

        [DataMember]
        public DateTime SendDate { get; set; }

        [DataMember]
        public bool IsFinished { get; set; }

        [DataMember]
        public bool IsReadyToSend { get; set; }

        [DataMember]
        public bool IsSent { get; set; }

        [DataMember]
        public string Notes { get; set; }

        public Payment Payment { get; set; }
        public User User { get; set; }
        public virtual ICollection<Detail> Details { get; set; }
    }
}