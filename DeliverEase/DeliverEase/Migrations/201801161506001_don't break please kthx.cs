namespace DeliverEase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dontbreakpleasekthx : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DeliveryDrivers", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.DeliveryDrivers", "UserId");
            AddForeignKey("dbo.DeliveryDrivers", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DeliveryDrivers", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.DeliveryDrivers", new[] { "UserId" });
            DropColumn("dbo.DeliveryDrivers", "UserId");
        }
    }
}
