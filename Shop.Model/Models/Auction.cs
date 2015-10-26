using System;

namespace Shop.Model.Models
{
    public class Auction
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public DateTime AuctionStart { get; set; }
        public DateTime AuctionEnd { get; set; }
        public String Content { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }

        public Category Category { get; set; }
        public User User { get; set; }
    }
}