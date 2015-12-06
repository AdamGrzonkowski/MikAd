using System.Collections.Generic;

namespace Shop.Model.Models
{
    public class Basket
    {
        public string UserId { get; set; }

        public User User { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}