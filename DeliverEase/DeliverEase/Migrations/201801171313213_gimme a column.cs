namespace DeliverEase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gimmeacolumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menus", "Order_OrderId", c => c.Int());
            CreateIndex("dbo.Menus", "Order_OrderId");
            AddForeignKey("dbo.Menus", "Order_OrderId", "dbo.Orders", "OrderId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Menus", "Order_OrderId", "dbo.Orders");
            DropIndex("dbo.Menus", new[] { "Order_OrderId" });
            DropColumn("dbo.Menus", "Order_OrderId");
        }
    }
}
