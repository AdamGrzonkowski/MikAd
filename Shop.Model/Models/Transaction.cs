using System.Collections.Generic;

namespace Shop.Model.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }

        public User User { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}