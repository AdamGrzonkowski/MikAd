using System.Runtime.Serialization;

namespace Shop.Model.Models
{
    [DataContract]
    public class Image
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int ProductId { get; set; }

        [DataMember]
        public string Url { get; set; }

        public virtual Product Product { get; set; }
    }
}