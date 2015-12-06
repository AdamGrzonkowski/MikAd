namespace Shop.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JsonPropertyCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "JsonProperties", c => c.String());
            AddColumn("dbo.Products", "Description", c => c.String());
            DropColumn("dbo.Categories", "Properties");
            DropColumn("dbo.Products", "Content");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Content", c => c.String());
            AddColumn("dbo.Categories", "Properties", c => c.String());
            DropColumn("dbo.Products", "Description");
            DropColumn("dbo.Categories", "JsonProperties");
        }
    }
}
