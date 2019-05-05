namespace CenturyAirlines.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateflights8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RACS_Flights", "SelectedDepartingFromCity", c => c.String(nullable: false));
            AlterColumn("dbo.RACS_Flights", "FlightCode", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RACS_Flights", "FlightCode", c => c.String());
            DropColumn("dbo.RACS_Flights", "SelectedDepartingFromCity");
        }
    }
}
