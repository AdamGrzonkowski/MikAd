namespace Shop.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JsonProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Properties", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "Properties");
        }
    }
}
