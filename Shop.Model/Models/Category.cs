using System.Collections.Generic;

namespace Shop.Model.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? BaseCategoryId { get; set; }
        public string Properties { get; set; }

        public virtual Category BaseCategory { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Category> SubCategories { get; set; }
    }
}