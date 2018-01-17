namespace DeliverEase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fuckingfuckingfuck : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "menuItemId_Id", c => c.Int());
            CreateIndex("dbo.Orders", "menuItemId_Id");
            AddForeignKey("dbo.Orders", "menuItemId_Id", "dbo.Menus", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "menuItemId_Id", "dbo.Menus");
            DropIndex("dbo.Orders", new[] { "menuItemId_Id" });
            DropColumn("dbo.Orders", "menuItemId_Id");
        }
    }
}
