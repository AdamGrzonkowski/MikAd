namespace Shop.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AuctionToProduct : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Auctions", newName: "Products");
            RenameColumn(table: "dbo.Reviews", name: "AuctionId", newName: "ProductId");
            RenameIndex(table: "dbo.Reviews", name: "IX_AuctionId", newName: "IX_ProductId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Reviews", name: "IX_ProductId", newName: "IX_AuctionId");
            RenameColumn(table: "dbo.Reviews", name: "ProductId", newName: "AuctionId");
            RenameTable(name: "dbo.Products", newName: "Auctions");
        }
    }
}
