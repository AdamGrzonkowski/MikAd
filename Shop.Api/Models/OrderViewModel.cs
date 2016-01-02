using System.Collections.Generic;

namespace Shop.Api.Models
{
    public class OrderViewModel
    {
        public string Notes { get; set; }

        public Dictionary<int, int> Details { get; set; }
    }
}