
using System.ComponentModel.DataAnnotations;

namespace Shop.Model.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nazwa produktu")]
        public string Name { get; set; }

        [Display(Name = "Ilość")]
        public int Amount { get; set; }

        [Display(Name = "Cena")]
        public decimal Price { get; set; }

        [Display(Name = "Stan")]
        public int Stock { get; set; }
    }
}