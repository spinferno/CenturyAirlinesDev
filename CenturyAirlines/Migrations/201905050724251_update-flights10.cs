namespace CenturyAirlines.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateflights10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RACS_Flights", "DepartingFromCityIndex", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RACS_Flights", "DepartingFromCityIndex");
        }
    }
}
