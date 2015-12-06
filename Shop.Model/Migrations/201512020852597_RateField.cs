namespace Shop.Model.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class RateField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "Rate", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reviews", "Rate");
        }
    }
}
