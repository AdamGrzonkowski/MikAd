using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.WebPages;
using Newtonsoft.Json;

namespace Shop.Model.Models
{
    [DataContract]
    public class Product : BaseEntity
    {

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
        public string Photo { get; set; }

        [NotMapped]
        public HttpPostedFileBase PhotoUpload { get; set; }

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

        [DataMember]
        public virtual ICollection<Review> Reviews { get; set; }

        [DataMember]
        public virtual ICollection<Image> Images { get; set; }

        public virtual ICollection<Detail> Details { get; set; }
    }
}