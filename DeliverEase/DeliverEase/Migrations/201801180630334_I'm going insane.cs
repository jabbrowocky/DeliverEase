namespace DeliverEase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Imgoinginsane : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Deliveries", "Age");
            DropColumn("dbo.Orders", "TimeSubmitted");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "TimeSubmitted", c => c.DateTime(nullable: false));
            AddColumn("dbo.Deliveries", "Age", c => c.DateTime(nullable: false));
        }
    }
}
