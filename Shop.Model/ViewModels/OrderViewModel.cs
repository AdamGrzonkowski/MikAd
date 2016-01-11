using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Model.ViewModels
{
    public class OrderViewModel
    {
        public List<ProductViewModel> Basket { get; set; }
        public string Notes { get; set; }
        public int Consignment { get; set; }
    }
}