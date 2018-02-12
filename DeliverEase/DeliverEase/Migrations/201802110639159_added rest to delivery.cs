namespace DeliverEase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedresttodelivery : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ToDelivers", "Rest_RestaurantId", c => c.Int());
            CreateIndex("dbo.ToDelivers", "Rest_RestaurantId");
            AddForeignKey("dbo.ToDelivers", "Rest_RestaurantId", "dbo.Restaurants", "RestaurantId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ToDelivers", "Rest_RestaurantId", "dbo.Restaurants");
            DropIndex("dbo.ToDelivers", new[] { "Rest_RestaurantId" });
            DropColumn("dbo.ToDelivers", "Rest_RestaurantId");
        }
    }
}
