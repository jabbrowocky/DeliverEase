namespace DeliverEase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testing : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Selection_RestaurantId", c => c.Int());
            CreateIndex("dbo.Orders", "Selection_RestaurantId");
            AddForeignKey("dbo.Orders", "Selection_RestaurantId", "dbo.Restaurants", "RestaurantId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Selection_RestaurantId", "dbo.Restaurants");
            DropIndex("dbo.Orders", new[] { "Selection_RestaurantId" });
            DropColumn("dbo.Orders", "Selection_RestaurantId");
        }
    }
}
