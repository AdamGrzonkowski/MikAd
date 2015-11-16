using System.Data.Entity;
using System.Data.Entity.Migrations;
using Microsoft.AspNet.Identity.EntityFramework;
using Shop.Model.Helpers;
using Shop.Model.Migrations;

namespace Shop.Model.Models
{
    public class ShopContext : IdentityDbContext<User>
    {
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public ShopContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ShopContext Create()
        {
            return new ShopContext();
        }
    }
}