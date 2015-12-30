using System.Runtime.Serialization;

namespace Shop.Model.Models
{
    [DataContract]
    public class Detail : BaseEntity
    {

        [DataMember]
        public int OrderId { get; set; }

        [DataMember]
        public int ProductId { get; set; }

        [DataMember]
        public int Amount { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}