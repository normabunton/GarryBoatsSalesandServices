namespace GarryBoats.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updted : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RepairPerson",
                c => new
                    {
                        RepairPersonId = c.Int(nullable: false, identity: true),
                        RepairPersonName = c.String(nullable: false),
                        RepairPersonLocation = c.String(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.RepairPersonId);
            
            CreateTable(
                "dbo.Repair",
                c => new
                    {
                        RepairId = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        RepairPersonId = c.String(nullable: false),
                        RepairDetails = c.String(nullable: false),
                        RepairDescription = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        Product = c.String(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.RepairId);
            
            AddColumn("dbo.Product", "ProductName", c => c.String(nullable: false));
            AddColumn("dbo.Product", "ProductDescription", c => c.String(nullable: false));
            DropColumn("dbo.Product", "Name");
            DropColumn("dbo.Product", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "Description", c => c.String(nullable: false));
            AddColumn("dbo.Product", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Product", "ProductDescription");
            DropColumn("dbo.Product", "ProductName");
            DropTable("dbo.Repair");
            DropTable("dbo.RepairPerson");
        }
    }
}
