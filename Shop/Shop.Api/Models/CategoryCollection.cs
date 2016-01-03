﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Shop.Models;

namespace Shop.Models
{
    public static partial class CategoryCollection
    {
        /// <summary>
        /// Deserialize the object
        /// </summary>
        public static IList<Category> DeserializeJson(JToken inputObject)
        {
            IList<Category> deserializedObject = new List<Category>();
            foreach (JToken iListValue in ((JArray)inputObject))
            {
                Category category = new Category();
                category.DeserializeJson(iListValue);
                deserializedObject.Add(category);
            }
            return deserializedObject;
        }
    }
}