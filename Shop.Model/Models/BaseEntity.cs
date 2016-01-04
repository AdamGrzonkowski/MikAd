﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Runtime.Serialization;

namespace Shop.Model.Models
{
    [DataContract]
    public class BaseEntity
    {
        [DataMember]
        public int Id { get; set; }

        public DateTime AddedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string IP { get; set; } 
    }
}