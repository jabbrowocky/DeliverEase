namespace DeliverEase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class workgoddamnit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DeliveryDrivers",
                c => new
                    {
                        DriverId = c.Int(nullable: false, identity: true),
                        DriverFirstName = c.String(),
                        DriverLastName = c.String(),
                    })
                .PrimaryKey(t => t.DriverId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DeliveryDrivers");
        }
    }
}
