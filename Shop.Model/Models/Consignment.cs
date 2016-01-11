using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shop.Model.Models
{
    public class Consignment : BaseEntity
    {
        [Display(Name = "Sposób dostawy")]
        public string Name { get; set; }
        [Display(Name = "Koszt dostawy")]
        public decimal Cost { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}