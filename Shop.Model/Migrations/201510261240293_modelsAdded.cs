namespace Shop.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelsAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Auctions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        AuctionStart = c.DateTime(nullable: false),
                        AuctionEnd = c.DateTime(nullable: false),
                        Content = c.String(),
                        Amount = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.CategoryId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BaseCategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.BaseCategoryId)
                .Index(t => t.BaseCategoryId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CommentText = c.String(),
                        CommentDate = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        AuthorId = c.Int(nullable: false),
                        Author_Id = c.String(maxLength: 128),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Author_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.Author_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "Author_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Auctions", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Auctions", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Categories", "BaseCategoryId", "dbo.Categories");
            DropIndex("dbo.Comments", new[] { "User_Id" });
            DropIndex("dbo.Comments", new[] { "Author_Id" });
            DropIndex("dbo.Categories", new[] { "BaseCategoryId" });
            DropIndex("dbo.Auctions", new[] { "User_Id" });
            DropIndex("dbo.Auctions", new[] { "CategoryId" });
            DropTable("dbo.Comments");
            DropTable("dbo.Categories");
            DropTable("dbo.Auctions");
        }
    }
}
