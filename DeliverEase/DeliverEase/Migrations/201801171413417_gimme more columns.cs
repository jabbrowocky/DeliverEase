namespace DeliverEase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gimmemorecolumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "OrderCost", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "OrderCost");
        }
    }
}
