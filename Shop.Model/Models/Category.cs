using System.Collections.Generic;

namespace Shop.Model.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? BaseCategoryId { get; set; }

        public virtual Category BaseCategory { get; set; }
        public virtual ICollection<Auction> Auctions { get; set; }
    }
}