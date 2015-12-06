namespace Shop.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransactionAndBasketModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Baskets",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            AddColumn("dbo.Products", "Basket_UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.Products", "Transaction_Id", c => c.Int());
            AddColumn("dbo.AspNetUsers", "BasketId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "Basket_UserId");
            CreateIndex("dbo.Products", "Transaction_Id");
            AddForeignKey("dbo.Products", "Basket_UserId", "dbo.Baskets", "UserId");
            AddForeignKey("dbo.Products", "Transaction_Id", "dbo.Transactions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Products", "Transaction_Id", "dbo.Transactions");
            DropForeignKey("dbo.Baskets", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Products", "Basket_UserId", "dbo.Baskets");
            DropIndex("dbo.Transactions", new[] { "UserId" });
            DropIndex("dbo.Products", new[] { "Transaction_Id" });
            DropIndex("dbo.Products", new[] { "Basket_UserId" });
            DropIndex("dbo.Baskets", new[] { "UserId" });
            DropColumn("dbo.AspNetUsers", "BasketId");
            DropColumn("dbo.Products", "Transaction_Id");
            DropColumn("dbo.Products", "Basket_UserId");
            DropTable("dbo.Transactions");
            DropTable("dbo.Baskets");
        }
    }
}
