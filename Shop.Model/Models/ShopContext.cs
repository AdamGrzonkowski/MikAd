using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Shop.Model.Models
{
    public class ShopContext : IdentityDbContext<User>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Transaction> Transactions { get; set; }


        public ShopContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
                .HasRequired(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Review>()
                .HasRequired(x => x.Product)
                .WithMany(x => x.Reviews)
                .HasForeignKey(x => x.ProductId);
            modelBuilder.Entity<Review>()
                .HasRequired(x => x.Author)
                .WithMany(x => x.Reviews)
                .HasForeignKey(x => x.AuthorId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Category>()
                .HasOptional(x => x.BaseCategory)
                .WithMany(x => x.SubCategories)
                .HasForeignKey(x => x.BaseCategoryId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Basket>()
                .HasKey(x => x.UserId);
            modelBuilder.Entity<Basket>()
                .HasRequired(x => x.User)
                .WithOptional(x => x.Basket);
        }

        public static ShopContext Create()
        {
            return new ShopContext();
        }
    }
}