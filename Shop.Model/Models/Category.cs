using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web.WebPages;
using Newtonsoft.Json;

namespace Shop.Model.Models
{
    [DataContract]
    public class Category : BaseEntity
    {

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int? BaseCategoryId { get; set; }

        public string JsonProperties { get; set; }

        [DataMember]
        [NotMapped]
        public List<string> Properties
        {
            get
            {
                if (JsonProperties.IsEmpty())
                    return null;
                return JsonConvert.DeserializeObject<List<string>>(JsonProperties);
            }
            set { JsonProperties = JsonConvert.SerializeObject(value); }
        }

        public virtual Category BaseCategory { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public virtual ICollection<Category> SubCategories { get; set; }

        [DataMember]
        [NotMapped]
        public ICollection<int> SubCategoryIds
        {
            get { return SubCategories == null ? null : SubCategories.Select(x => x.Id).ToList(); }
        }
    }
}