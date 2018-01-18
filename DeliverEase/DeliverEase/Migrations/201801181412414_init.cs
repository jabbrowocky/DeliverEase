namespace DeliverEase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
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
                        UserId = c.String(maxLength: 128),
                        HasDelivery = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DriverId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        OrderDetails = c.String(),
                        OrderCost = c.Double(nullable: false),
                        IsAccepted = c.Boolean(nullable: false),
                        IsSubmitted = c.Boolean(nullable: false),
                        ToDeliverId = c.Int(nullable: false),
                        menuItemId_Id = c.Int(),
                        Selection_RestaurantId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.ToDelivers", t => t.ToDeliverId, cascadeDelete: true)
                .ForeignKey("dbo.Menus", t => t.menuItemId_Id)
                .ForeignKey("dbo.Restaurants", t => t.Selection_RestaurantId)
                .Index(t => t.CustomerId)
                .Index(t => t.ToDeliverId)
                .Index(t => t.menuItemId_Id)
                .Index(t => t.Selection_RestaurantId);
            
            CreateTable(
                "dbo.ToDelivers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        IsDelivered = c.Boolean(nullable: false),
                        IsAccepted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Menus", "Order_OrderId", c => c.Int());
            AddColumn("dbo.Restaurants", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Menus", "Order_OrderId");
            CreateIndex("dbo.Restaurants", "UserId");
            AddForeignKey("dbo.Restaurants", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Menus", "Order_OrderId", "dbo.Orders", "OrderId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Selection_RestaurantId", "dbo.Restaurants");
            DropForeignKey("dbo.Menus", "Order_OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "menuItemId_Id", "dbo.Menus");
            DropForeignKey("dbo.Orders", "ToDeliverId", "dbo.ToDelivers");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Restaurants", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.DeliveryDrivers", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Orders", new[] { "Selection_RestaurantId" });
            DropIndex("dbo.Orders", new[] { "menuItemId_Id" });
            DropIndex("dbo.Orders", new[] { "ToDeliverId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.Restaurants", new[] { "UserId" });
            DropIndex("dbo.Menus", new[] { "Order_OrderId" });
            DropIndex("dbo.DeliveryDrivers", new[] { "UserId" });
            DropColumn("dbo.Restaurants", "UserId");
            DropColumn("dbo.Menus", "Order_OrderId");
            DropTable("dbo.ToDelivers");
            DropTable("dbo.Orders");
            DropTable("dbo.DeliveryDrivers");
        }
    }
}
