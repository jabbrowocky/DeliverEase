namespace DeliverEase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pleaseworkffs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "DeliveryId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "DeliveryId");
        }
    }
}
