using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Shop.Model.Models;

namespace Shop.DataEntry
{
    public class ShopContext : IdentityDbContext<User>
    {
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Detail> Details { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Consignment> Consignments { get; set; }


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
            modelBuilder.Entity<Image>()
                .HasRequired(x => x.Product)
                .WithMany(x => x.Images)
                .HasForeignKey(x => x.ProductId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Detail>()
                .HasRequired(x => x.Order)
                .WithMany(x => x.Details)
                .HasForeignKey(x => x.OrderId)
                .WillCascadeOnDelete(true);
            modelBuilder.Entity<Detail>()
                .HasRequired(x => x.Product)
                .WithMany(x => x.Details)
                .HasForeignKey(x => x.ProductId)
                .WillCascadeOnDelete(true);
            modelBuilder.Entity<Order>()
                .HasRequired(x => x.User)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.UserId);
            modelBuilder.Entity<Order>()
                .HasOptional(x => x.Payment)
                .WithRequired(x => x.Order);
            modelBuilder.Entity<Order>()
                .HasRequired(x => x.Consignment)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.ConsignmentId);
        }

        public static ShopContext Create()
        {
            return new ShopContext();
        }
    }
}