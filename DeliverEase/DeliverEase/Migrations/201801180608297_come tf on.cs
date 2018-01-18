namespace DeliverEase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cometfon : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Deliveries", "DriverId", c => c.Int(nullable: false));
            AddColumn("dbo.Deliveries", "IsDelivered", c => c.Boolean(nullable: false));
            AddColumn("dbo.Deliveries", "Age", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Deliveries", "Age");
            DropColumn("dbo.Deliveries", "IsDelivered");
            DropColumn("dbo.Deliveries", "DriverId");
        }
    }
}
