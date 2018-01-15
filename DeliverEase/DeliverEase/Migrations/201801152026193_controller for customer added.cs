namespace DeliverEase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class controllerforcustomeradded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerFirstName = c.String(),
                        CustomerLastName = c.String(),
                        CustomerAdress = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Customers");
        }
    }
}
