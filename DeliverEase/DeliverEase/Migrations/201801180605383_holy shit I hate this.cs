namespace DeliverEase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class holyshitIhatethis : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Deliveries", "CustomerId", "dbo.Orders");
            DropIndex("dbo.Deliveries", new[] { "CustomerId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Deliveries", "CustomerId");
            AddForeignKey("dbo.Deliveries", "CustomerId", "dbo.Orders", "OrderId", cascadeDelete: true);
        }
    }
}
