namespace DeliverEase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gimmecolumnsorgimmedeath : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "OrderDetails", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "OrderDetails");
        }
    }
}
