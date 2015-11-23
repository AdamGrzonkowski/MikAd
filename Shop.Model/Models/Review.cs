using System;

namespace Shop.Model.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string ReviewText { get; set; }
        public DateTime ReviewTime { get; set; }
        public int AuctionId { get; set; }
        public string AuthorId { get; set; }

        public Auction Auction { get; set; }
        public User Author { get; set; }
    }
}