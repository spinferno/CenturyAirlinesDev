namespace CenturyAirlines.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateflights6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RACS_Flights", "IsFull", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RACS_Flights", "IsFull");
        }
    }
}
