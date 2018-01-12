namespace DeliverEase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tiredofthis : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MenuItem = c.String(),
                        ItemPrice = c.Double(nullable: false),
                        RestaurantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantId, cascadeDelete: true)
                .Index(t => t.RestaurantId);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        RestaurantId = c.Int(nullable: false, identity: true),
                        RestaurantName = c.String(),
                    })
                .PrimaryKey(t => t.RestaurantId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Menus", "RestaurantId", "dbo.Restaurants");
            DropIndex("dbo.Menus", new[] { "RestaurantId" });
            DropTable("dbo.Restaurants");
            DropTable("dbo.Menus");
        }
    }
}
