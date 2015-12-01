using System.Collections.Generic;

namespace Shop.Model.Models
{
    public class Auction
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Content { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<AuctionProperty> Properties { get; set; }
    }
}