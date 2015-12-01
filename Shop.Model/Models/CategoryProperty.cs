namespace Shop.Model.Models
{
    public class CategoryProperty
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public virtual Category Category { get; set; }
    }
}