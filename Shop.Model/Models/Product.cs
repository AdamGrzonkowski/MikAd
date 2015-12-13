using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Shop.Model.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public string JsonProperties { get; set; }
        [NotMapped]
        public Dictionary<string, string> Properties
        {
            get { return JsonConvert.DeserializeObject<Dictionary<string, string>>(JsonProperties); }
            set { JsonProperties = JsonConvert.SerializeObject(value); }
        }

        public virtual Category Category { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<Detail> Details { get; set; }
    }
}