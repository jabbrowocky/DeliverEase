namespace DeliverEase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eh : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "TimeSubmitted", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "TimeSubmitted");
        }
    }
}
