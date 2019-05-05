namespace CenturyAirlines.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateflights : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RACS_Bookings", "BookingCode", c => c.String());
            AddColumn("dbo.RACS_Flights", "DepatureTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.RACS_Flights", "ArrivalTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.RACS_Flights", "IsFull", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RACS_Flights", "IsFull");
            DropColumn("dbo.RACS_Flights", "ArrivalTime");
            DropColumn("dbo.RACS_Flights", "DepatureTime");
            DropColumn("dbo.RACS_Bookings", "BookingCode");
        }
    }
}
