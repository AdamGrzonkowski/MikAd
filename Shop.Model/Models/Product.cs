using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Web.WebPages;
using Newtonsoft.Json;

namespace Shop.Model.Models
{
    [DataContract]
    public class Product
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int CategoryId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int Amount { get; set; }

        [DataMember]
        public decimal Price { get; set; }

        public string JsonProperties { get; set; }

        [DataMember]
        [NotMapped]
        public Dictionary<string, string> Properties
        {
            get
            {
                if (JsonProperties.IsEmpty())
                    return null;
                return JsonConvert.DeserializeObject<Dictionary<string, string>>(JsonProperties);
            }
            set { JsonProperties = JsonConvert.SerializeObject(value); }
        }

        public virtual Category Category { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<Detail> Details { get; set; }
    }
}