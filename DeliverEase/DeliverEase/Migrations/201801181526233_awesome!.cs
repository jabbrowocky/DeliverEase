namespace DeliverEase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class awesome : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ToDelivers", "IsComplete", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ToDelivers", "IsComplete");
        }
    }
}
