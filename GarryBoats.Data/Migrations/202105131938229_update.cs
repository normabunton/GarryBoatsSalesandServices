namespace GarryBoats.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Repair", "RepairPersonId");
            DropColumn("dbo.Repair", "Location");
            DropColumn("dbo.Repair", "Product");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Repair", "Product", c => c.String());
            AddColumn("dbo.Repair", "Location", c => c.String(nullable: false));
            AddColumn("dbo.Repair", "RepairPersonId", c => c.String());
        }
    }
}
