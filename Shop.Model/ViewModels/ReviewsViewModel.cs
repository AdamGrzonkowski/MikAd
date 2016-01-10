using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using Shop.Model.Models;

namespace Shop.Model.ViewModels
{
    public class ReviewsViewModel
    {
        [DataMember]
        public string ReviewText { get; set; }

        [DataMember]
        public Rate Rate { get; set; }

        [DataMember]
        public string AuthorName { get; set; }
    }
}