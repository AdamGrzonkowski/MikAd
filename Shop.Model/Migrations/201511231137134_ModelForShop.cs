namespace Shop.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelForShop : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Auctions", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "Author_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Auctions", new[] { "User_Id" });
            DropIndex("dbo.Comments", new[] { "Author_Id" });
            DropIndex("dbo.Comments", new[] { "User_Id" });
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReviewText = c.String(),
                        ReviewTime = c.DateTime(nullable: false),
                        AuctionId = c.Int(nullable: false),
                        AuthorId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Auctions", t => t.AuctionId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.AuthorId, cascadeDelete: true)
                .Index(t => t.AuctionId)
                .Index(t => t.AuthorId);
            
            DropColumn("dbo.Auctions", "UserId");
            DropColumn("dbo.Auctions", "AuctionStart");
            DropColumn("dbo.Auctions", "AuctionEnd");
            DropColumn("dbo.Auctions", "User_Id");
            DropTable("dbo.Comments");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Auctions", "User_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Auctions", "AuctionEnd", c => c.DateTime(nullable: false));
            AddColumn("dbo.Auctions", "AuctionStart", c => c.DateTime(nullable: false));
            AddColumn("dbo.Auctions", "UserId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Reviews", "AuthorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Reviews", "AuctionId", "dbo.Auctions");
            DropIndex("dbo.Reviews", new[] { "AuthorId" });
            DropIndex("dbo.Reviews", new[] { "AuctionId" });
            DropTable("dbo.Reviews");
            CreateIndex("dbo.Comments", "User_Id");
            CreateIndex("dbo.Comments", "Author_Id");
            CreateIndex("dbo.Auctions", "User_Id");
            AddForeignKey("dbo.Comments", "User_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Comments", "Author_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Auctions", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
