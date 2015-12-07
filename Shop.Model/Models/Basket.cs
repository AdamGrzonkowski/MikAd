namespace Shop.Model.Models
{
    public class Basket
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }

        public virtual User User { get; set; }
        public virtual Product Product { get; set; }
    }
}