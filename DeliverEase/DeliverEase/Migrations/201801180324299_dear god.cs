namespace DeliverEase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deargod : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DeliveryDrivers", "HasDelivery", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DeliveryDrivers", "HasDelivery");
        }
    }
}
