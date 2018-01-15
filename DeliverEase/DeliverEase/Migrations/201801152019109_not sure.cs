namespace DeliverEase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notsure : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurants", "RestaurantAddress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Restaurants", "RestaurantAddress");
        }
    }
}
