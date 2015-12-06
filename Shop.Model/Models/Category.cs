using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Shop.Model.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? BaseCategoryId { get; set; }
        public string JsonProperties { get; set; }
        [NotMapped]
        public List<string> Properties
        {
            get { return JsonConvert.DeserializeObject<List<string>>(JsonProperties); }
            set { JsonProperties = JsonConvert.SerializeObject(value); }
        }

        public virtual Category BaseCategory { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Category> SubCategories { get; set; }
    }
}