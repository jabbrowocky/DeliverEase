namespace DeliverEase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class manfuckthis : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "IsSubmitted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "IsSubmitted");
        }
    }
}
