using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;

namespace Shop.Model.Models
{
    [DataContract]
    public class Order : BaseEntity
    {
        [Display(Name = "Użytkownik")]
        [DataMember]
        public string UserId { get; set; }

        [Display(Name = "Płatność")]
        [DataMember]
        public int PaymentId { get; set; }

        [Display(Name = "Wysyłka")]
        [DataMember]
        public int ConsignmentId { get; set; }

        [DataMember]
        [NotMapped]
        public decimal TotalPrice {
            get
            {
                return Details.Sum(detail => detail.Product.Price*detail.Amount);
            }
        }

        [NotMapped]
        public decimal PriceWithConsignment { get { return TotalPrice + Consignment.Cost; } }

        [DataMember]
        [NotMapped]
        public DateTime? OrderDate { get { return AddedDate; } }

        [Display(Name = "Data wysyłki")]
        [DataMember]
        public DateTime? SendDate { get; set; }

        [DataMember]
        [NotMapped]
        public bool IsPaid { get { return Payment == null || Payment.Amount < TotalPrice ? false : true; } }

        [Display(Name = "Gotowy do wysłania?")]
        [DataMember]
        public bool IsReadyToSend { get; set; }

        [DataMember]
        [NotMapped]
        public bool IsSent { get { return SendDate != null; } }

        [Display(Name = "Uwagi")]
        [DataMember]
        public string Notes { get; set; }

        public Payment Payment { get; set; }

        public User User { get; set; }

        public Consignment Consignment { get; set; }

        [DataMember]
        public virtual ICollection<Detail> Details { get; set; }

    }
}