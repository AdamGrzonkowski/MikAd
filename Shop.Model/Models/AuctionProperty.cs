namespace Shop.Model.Models
{
    public class AuctionProperty
    {
        public int Id { get; set; }
        public int AuctionId { get; set; }
        public int PropertyId { get; set; }
        public string Value { get; set; }

        public virtual CategoryProperty Property { get; set; }
        public virtual Auction Auction { get; set; }
    }
}