namespace DeliverEase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        CustomerFirstName = c.String(),
                        CustomerLastName = c.String(),
                        CustomerAdress = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        IsPending = c.Boolean(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.DeliveryDrivers",
                c => new
                    {
                        DriverId = c.Int(nullable: false, identity: true),
                        DriverFirstName = c.String(),
                        DriverLastName = c.String(),
                        UserId = c.String(maxLength: 128),
                        HasDelivery = c.Boolean(nullable: false),
                        Delivery_Id = c.Int(),
                    })
                .PrimaryKey(t => t.DriverId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.ToDelivers", t => t.Delivery_Id)
                .Index(t => t.UserId)
                .Index(t => t.Delivery_Id);
            
            CreateTable(
                "dbo.ToDelivers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                        CustomerAddress = c.String(),
                        OrderCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CustomerId = c.Int(nullable: false),
                        IsDelivered = c.Boolean(nullable: false),
                        IsAccepted = c.Boolean(nullable: false),
                        IsComplete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        OrderDetails = c.String(),
                        OrderCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsAccepted = c.Boolean(nullable: false),
                        IsSubmitted = c.Boolean(nullable: false),
                        IsAdded = c.Boolean(nullable: false),
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
                "dbo.Menus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MenuItem = c.String(),
                        ItemPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RestaurantId = c.Int(nullable: false),
                        Order_OrderId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Order_OrderId)
                .Index(t => t.RestaurantId)
                .Index(t => t.Order_OrderId);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        RestaurantId = c.Int(nullable: false, identity: true),
                        RestaurantName = c.String(),
                        RestaurantAddress = c.String(),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RestaurantId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.DeliveryDrivers", "Delivery_Id", "dbo.ToDelivers");
            DropForeignKey("dbo.Orders", "Selection_RestaurantId", "dbo.Restaurants");
            DropForeignKey("dbo.Menus", "Order_OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "menuItemId_Id", "dbo.Menus");
            DropForeignKey("dbo.Menus", "RestaurantId", "dbo.Restaurants");
            DropForeignKey("dbo.Restaurants", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Orders", "ToDeliverId", "dbo.ToDelivers");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.DeliveryDrivers", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Customers", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Restaurants", new[] { "UserId" });
            DropIndex("dbo.Menus", new[] { "Order_OrderId" });
            DropIndex("dbo.Menus", new[] { "RestaurantId" });
            DropIndex("dbo.Orders", new[] { "Selection_RestaurantId" });
            DropIndex("dbo.Orders", new[] { "menuItemId_Id" });
            DropIndex("dbo.Orders", new[] { "ToDeliverId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.DeliveryDrivers", new[] { "Delivery_Id" });
            DropIndex("dbo.DeliveryDrivers", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Customers", new[] { "UserId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Restaurants");
            DropTable("dbo.Menus");
            DropTable("dbo.Orders");
            DropTable("dbo.ToDelivers");
            DropTable("dbo.DeliveryDrivers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Customers");
        }
    }
}
