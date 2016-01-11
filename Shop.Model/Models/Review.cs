using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Shop.Model.Models
{
    public enum Rate
    {
        NieKupować = 1, Kiepski, Przeciętny, Dobry, BardzoDobry
    }

    [DataContract]
    public class Review : BaseEntity
    {
        [Display(Name = "Recenzja")]
        [DataMember]
        public string ReviewText { get; set; }

        [Display(Name = "Ocena")]
        [DataMember]
        public Rate Rate { get; set; }

        [Display(Name= "Twój nick")]
        [DataMember]
        public string AuthorName { get; set; }

        [DataMember]
        public int ProductId { get; set; }

        [DataMember]
        public string AuthorId { get; set; }

        public Product Product { get; set; }

        public User Author { get; set; }
    }
}