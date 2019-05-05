namespace CenturyAirlines.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatemigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RACS_Bookings",
                c => new
                    {
                        BookingID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.BookingID);
            
            CreateTable(
                "dbo.RACS_Cities",
                c => new
                    {
                        CityID = c.Int(nullable: false, identity: true),
                        CityName = c.String(),
                        CityCode = c.String(),
                    })
                .PrimaryKey(t => t.CityID);
            
            CreateTable(
                "dbo.RACS_Flights",
                c => new
                    {
                        FlightID = c.Int(nullable: false, identity: true),
                        FlightCode = c.String(),
                    })
                .PrimaryKey(t => t.FlightID);
            
            CreateTable(
                "dbo.CitiesFlights",
                c => new
                    {
                        Cities_CityID = c.Int(nullable: false),
                        Flight_FlightID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Cities_CityID, t.Flight_FlightID })
                .ForeignKey("dbo.RACS_Cities", t => t.Cities_CityID, cascadeDelete: true)
                .ForeignKey("dbo.RACS_Flights", t => t.Flight_FlightID, cascadeDelete: true)
                .Index(t => t.Cities_CityID)
                .Index(t => t.Flight_FlightID);
            
            CreateTable(
                "dbo.CitiesFlight1",
                c => new
                    {
                        Cities_CityID = c.Int(nullable: false),
                        Flight_FlightID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Cities_CityID, t.Flight_FlightID })
                .ForeignKey("dbo.RACS_Cities", t => t.Cities_CityID, cascadeDelete: true)
                .ForeignKey("dbo.RACS_Flights", t => t.Flight_FlightID, cascadeDelete: true)
                .Index(t => t.Cities_CityID)
                .Index(t => t.Flight_FlightID);
            
            DropTable("dbo.Employees");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 60),
                        JoiningDate = c.DateTime(nullable: false),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            DropForeignKey("dbo.CitiesFlight1", "Flight_FlightID", "dbo.RACS_Flights");
            DropForeignKey("dbo.CitiesFlight1", "Cities_CityID", "dbo.RACS_Cities");
            DropForeignKey("dbo.CitiesFlights", "Flight_FlightID", "dbo.RACS_Flights");
            DropForeignKey("dbo.CitiesFlights", "Cities_CityID", "dbo.RACS_Cities");
            DropIndex("dbo.CitiesFlight1", new[] { "Flight_FlightID" });
            DropIndex("dbo.CitiesFlight1", new[] { "Cities_CityID" });
            DropIndex("dbo.CitiesFlights", new[] { "Flight_FlightID" });
            DropIndex("dbo.CitiesFlights", new[] { "Cities_CityID" });
            DropTable("dbo.CitiesFlight1");
            DropTable("dbo.CitiesFlights");
            DropTable("dbo.RACS_Flights");
            DropTable("dbo.RACS_Cities");
            DropTable("dbo.RACS_Bookings");
        }
    }
}
