using System;
using System.Runtime.Serialization;

namespace Shop.Model.Models
{
    public enum Rate
    {
        VeryBad = 1, Bad, Average, Good, VeryGood
    }

    [DataContract]
    public class Review : BaseEntity
    {

        [DataMember]
        public string ReviewText { get; set; }

        [DataMember]
        public DateTime ReviewTime { get; set; }

        [DataMember]
        public Rate Rate { get; set; }

        [DataMember]
        public int ProductId { get; set; }

        [DataMember]
        public string AuthorId { get; set; }

        public Product Product { get; set; }
        public User Author { get; set; }
    }
}