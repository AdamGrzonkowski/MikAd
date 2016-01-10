using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.WebPages;
using Newtonsoft.Json;

namespace Shop.Model.Models
{
    [DataContract]
    public class Product : BaseEntity
    {

        [DataMember]
        [Display(Name = "Kategoria")]
        public int CategoryId { get; set; }

        [DataMember]
        [Display(Name = "Nazwa produktu")]
        public string Name { get; set; }

        [DataMember]
        [Display(Name = "Producent")]
        public string Producer { get; set; }

        [DataMember]
        [Display(Name = "Opis")]
        public string Description { get; set; }

        [DataMember]
        [Display(Name = "Ilość sztuk")]
        public int Amount { get; set; }

        [DataMember]
        [Display(Name = "Cena")]
        public decimal Price { get; set; }

        [Display(Name = "Zserializowane cechy produktu")]
        public string JsonProperties { get; set; }

        [DataMember]
        [Display(Name = "Ścieżka do pliku")]
        public string Photo { get; set; }

        [NotMapped]
        [Display(Name = "Zdjęcie produktu")]
        public HttpPostedFileBase PhotoUpload { get; set; }

        [Display(Name = "Polecane")]
        public bool Featured { get; set; }

        [DataMember]
        [NotMapped]
        public Dictionary<string, string> Properties
        {
            get
            {
                if (JsonProperties.IsEmpty())
                    return null;
                return JsonConvert.DeserializeObject<Dictionary<string, string>>(JsonProperties);
            }
            set { JsonProperties = JsonConvert.SerializeObject(value); }
        }

        [Display(Name = "Kategoria")]
        public virtual Category Category { get; set; }

        [DataMember]
        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public virtual ICollection<Detail> Details { get; set; }
    }
}