using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Shop.Model.Models
{
    public class ShopContext : IdentityDbContext<User>
    {
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<CategoryProperty> CategoryProperties { get; set; }
        public DbSet<AuctionProperty> AuctionProperties { get; set; }


        public ShopContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Auction>()
                .HasRequired(x => x.Category)
                .WithMany(x => x.Auctions)
                .HasForeignKey(x => x.CategoryId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Review>()
                .HasRequired(x => x.Auction)
                .WithMany(x => x.Reviews)
                .HasForeignKey(x => x.AuctionId);
            modelBuilder.Entity<Review>()
                .HasRequired(x => x.Author)
                .WithMany(x => x.Reviews)
                .HasForeignKey(x => x.AuthorId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Category>()
                .HasMany(x => x.Properties)
                .WithRequired()
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<CategoryProperty>()
                .HasRequired(x => x.Category)
                .WithMany(x => x.Properties)
                .HasForeignKey(x => x.CategoryId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<AuctionProperty>()
                .HasRequired(x => x.Auction)
                .WithMany(x => x.Properties)
                .HasForeignKey(x => x.AuctionId);
        }

        public static ShopContext Create()
        {
            return new ShopContext();
        }
    }
}