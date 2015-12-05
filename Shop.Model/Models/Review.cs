using System;

namespace Shop.Model.Models
{
    public enum Rate
    {
        VeryBad = 1, Bad, Average, Good, VeryGood
    }

    public class Review
    {
        public int Id { get; set; }
        public string ReviewText { get; set; }
        public DateTime ReviewTime { get; set; }
        public Rate Rate { get; set; }
        public int ProductId { get; set; }
        public string AuthorId { get; set; }

        public Product Product { get; set; }
        public User Author { get; set; }
    }
}