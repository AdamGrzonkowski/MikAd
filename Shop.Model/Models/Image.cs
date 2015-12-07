namespace Shop.Model.Models
{
    public class Image
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Url { get; set; }

        public virtual Product Product { get; set; }
    }
}