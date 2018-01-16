namespace DeliverEase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedrestaurantmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurants", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Restaurants", "UserId");
            AddForeignKey("dbo.Restaurants", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Restaurants", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Restaurants", new[] { "UserId" });
            DropColumn("dbo.Restaurants", "UserId");
        }
    }
}
