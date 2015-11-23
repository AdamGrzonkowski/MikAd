using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Shop.Model.Models
{
    public class ShopContext : IdentityDbContext<User>
    {
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Review> Reviews { get; set; }

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
                .HasForeignKey(x => x.CategoryId);
            modelBuilder.Entity<Review>()
                .HasRequired(x => x.Auction)
                .WithMany(x => x.Reviews)
                .HasForeignKey(x => x.AuctionId);
            modelBuilder.Entity<Review>()
                .HasRequired(x => x.Author)
                .WithMany(x => x.Reviews)
                .HasForeignKey(x => x.AuthorId);

        }

        public static ShopContext Create()
        {
            return new ShopContext();
        }
    }
}