using System.Collections.Generic;

namespace Shop.Model.Models
{
    public class Consignment : BaseEntity
    {
        public string Name { get; set; }
        public decimal Cost { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}