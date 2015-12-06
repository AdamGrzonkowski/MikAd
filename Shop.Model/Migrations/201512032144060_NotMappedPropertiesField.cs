namespace Shop.Model.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class NotMappedPropertiesField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "JSONProperties", c => c.String());
            DropColumn("dbo.Products", "Properties");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Properties", c => c.String());
            DropColumn("dbo.Products", "JSONProperties");
        }
    }
}
