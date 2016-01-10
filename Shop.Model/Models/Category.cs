using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Web.WebPages;

namespace Shop.Model.Models
{
    [DataContract]
    public class Category : BaseEntity
    {
        
        [DataMember]
        [Display(Name = "Nazwa kategorii")]
        public string Name { get; set; }

        [DataMember]
        [Display(Name = "Kategoria nadrzędna")]
        public int? BaseCategoryId { get; set; }

        [Display(Name = "Zserializowane cechy produktu")]
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

        public virtual ICollection<Category> BaseCategoryCategories{ get; set; }

        //[DataMember]
        //[NotMapped]
        //public List<int> SubCategoryIds
        //{
        //    get { var ids = from subCategory in SubCategories 
        //        select subCategory.Id;
        //        return ids.ToList();
        //    }
        //}
    }
}