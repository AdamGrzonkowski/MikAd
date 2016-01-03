﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Rest;
using Newtonsoft.Json.Linq;
using Shop.Models;

namespace Shop.Models
{
    public partial class Product
    {
        private int? _amount;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int? Amount
        {
            get { return this._amount; }
            set { this._amount = value; }
        }
        
        private int? _categoryId;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int? CategoryId
        {
            get { return this._categoryId; }
            set { this._categoryId = value; }
        }
        
        private string _description;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string Description
        {
            get { return this._description; }
            set { this._description = value; }
        }
        
        private int? _id;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int? Id
        {
            get { return this._id; }
            set { this._id = value; }
        }
        
        private IList<Image> _images;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public IList<Image> Images
        {
            get { return this._images; }
            set { this._images = value; }
        }
        
        private string _name;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }
        
        private string _photo;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string Photo
        {
            get { return this._photo; }
            set { this._photo = value; }
        }
        
        private double? _price;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public double? Price
        {
            get { return this._price; }
            set { this._price = value; }
        }
        
        private IDictionary<string, string> _properties;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public IDictionary<string, string> Properties
        {
            get { return this._properties; }
            set { this._properties = value; }
        }
        
        private IList<Review> _reviews;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public IList<Review> Reviews
        {
            get { return this._reviews; }
            set { this._reviews = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the Product class.
        /// </summary>
        public Product()
        {
            this.Images = new LazyList<Image>();
            this.Properties = new LazyDictionary<string, string>();
            this.Reviews = new LazyList<Review>();
        }
        
        /// <summary>
        /// Deserialize the object
        /// </summary>
        public virtual void DeserializeJson(JToken inputObject)
        {
            if (inputObject != null && inputObject.Type != JTokenType.Null)
            {
                JToken amountValue = inputObject["Amount"];
                if (amountValue != null && amountValue.Type != JTokenType.Null)
                {
                    this.Amount = ((int)amountValue);
                }
                JToken categoryIdValue = inputObject["CategoryId"];
                if (categoryIdValue != null && categoryIdValue.Type != JTokenType.Null)
                {
                    this.CategoryId = ((int)categoryIdValue);
                }
                JToken descriptionValue = inputObject["Description"];
                if (descriptionValue != null && descriptionValue.Type != JTokenType.Null)
                {
                    this.Description = ((string)descriptionValue);
                }
                JToken idValue = inputObject["Id"];
                if (idValue != null && idValue.Type != JTokenType.Null)
                {
                    this.Id = ((int)idValue);
                }
                JToken imagesSequence = ((JToken)inputObject["Images"]);
                if (imagesSequence != null && imagesSequence.Type != JTokenType.Null)
                {
                    foreach (JToken imagesValue in ((JArray)imagesSequence))
                    {
                        Image image = new Image();
                        image.DeserializeJson(imagesValue);
                        this.Images.Add(image);
                    }
                }
                JToken nameValue = inputObject["Name"];
                if (nameValue != null && nameValue.Type != JTokenType.Null)
                {
                    this.Name = ((string)nameValue);
                }
                JToken photoValue = inputObject["Photo"];
                if (photoValue != null && photoValue.Type != JTokenType.Null)
                {
                    this.Photo = ((string)photoValue);
                }
                JToken priceValue = inputObject["Price"];
                if (priceValue != null && priceValue.Type != JTokenType.Null)
                {
                    this.Price = ((double)priceValue);
                }
                JToken reviewsSequence = ((JToken)inputObject["Reviews"]);
                if (reviewsSequence != null && reviewsSequence.Type != JTokenType.Null)
                {
                    foreach (JToken reviewsValue in ((JArray)reviewsSequence))
                    {
                        Review review = new Review();
                        review.DeserializeJson(reviewsValue);
                        this.Reviews.Add(review);
                    }
                }
                JToken stringDictionary = ((JToken)inputObject["String"]);
                if (stringDictionary != null && stringDictionary.Type != JTokenType.Null)
                {
                    foreach (JProperty property in stringDictionary)
                    {
                        this.Properties.Add(((string)property.Name), ((string)property.Value));
                    }
                }
            }
        }
    }
}