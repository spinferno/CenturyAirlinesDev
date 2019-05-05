namespace CenturyAirlines.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateflights19 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RACS_Flights", "ArrivalCityID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RACS_Flights", "ArrivalCityID");
        }
    }
}