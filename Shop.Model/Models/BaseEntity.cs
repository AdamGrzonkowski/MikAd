using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Shop.Model.Models
{
    [DataContract]
    public class BaseEntity
    {
        [DataMember]
        public int Id { get; set; }
        [Display(Name = "Data dodania")]
        public DateTime AddedDate { get; set; }

        [Display(Name = "Data edycji")]
        public DateTime ModifiedDate { get; set; }

        [Display(Name = "Adres IP dodającego")]
        public string IP { get; set; } 
    }
}