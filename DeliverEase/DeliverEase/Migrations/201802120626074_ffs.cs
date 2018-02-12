namespace DeliverEase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ffs : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "IsAccepted");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "IsAccepted", c => c.Boolean(nullable: false));
        }
    }
}
