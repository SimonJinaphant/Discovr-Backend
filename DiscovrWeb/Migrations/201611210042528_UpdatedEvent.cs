namespace DiscovrWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedEvent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Guid", c => c.Guid(nullable: false));
            AddColumn("dbo.Events", "LastUpdated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "LastUpdated");
            DropColumn("dbo.Events", "Guid");
        }
    }
}
