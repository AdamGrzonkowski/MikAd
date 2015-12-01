namespace Shop.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedProperties : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuctionProperties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AuctionId = c.Int(nullable: false),
                        PropertyId = c.Int(nullable: false),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Auctions", t => t.AuctionId, cascadeDelete: true)
                .ForeignKey("dbo.CategoryProperties", t => t.PropertyId, cascadeDelete: true)
                .Index(t => t.AuctionId)
                .Index(t => t.PropertyId);
            
            CreateTable(
                "dbo.CategoryProperties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AuctionProperties", "PropertyId", "dbo.CategoryProperties");
            DropForeignKey("dbo.AuctionProperties", "AuctionId", "dbo.Auctions");
            DropForeignKey("dbo.CategoryProperties", "CategoryId", "dbo.Categories");
            DropIndex("dbo.CategoryProperties", new[] { "CategoryId" });
            DropIndex("dbo.AuctionProperties", new[] { "PropertyId" });
            DropIndex("dbo.AuctionProperties", new[] { "AuctionId" });
            DropTable("dbo.CategoryProperties");
            DropTable("dbo.AuctionProperties");
        }
    }
}
