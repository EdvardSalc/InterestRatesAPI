namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agreements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        BaseRateCode = c.String(),
                        Margin = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AgreementDuration = c.Int(nullable: false),
                        Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PersonalId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Agreements", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Agreements", new[] { "Customer_Id" });
            DropTable("dbo.Customers");
            DropTable("dbo.Agreements");
        }
    }
}
