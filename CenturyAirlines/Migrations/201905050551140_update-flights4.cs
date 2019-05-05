namespace CenturyAirlines.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateflights4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CitiesFlights", "Cities_CityID", "dbo.RACS_Cities");
            DropForeignKey("dbo.CitiesFlights", "Flight_FlightID", "dbo.RACS_Flights");
            DropForeignKey("dbo.CitiesFlight1", "Cities_CityID", "dbo.RACS_Cities");
            DropForeignKey("dbo.CitiesFlight1", "Flight_FlightID", "dbo.RACS_Flights");
            DropIndex("dbo.CitiesFlights", new[] { "Cities_CityID" });
            DropIndex("dbo.CitiesFlights", new[] { "Flight_FlightID" });
            DropIndex("dbo.CitiesFlight1", new[] { "Cities_CityID" });
            DropIndex("dbo.CitiesFlight1", new[] { "Flight_FlightID" });
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        FlightID = c.Int(nullable: false, identity: true),
                        FlightCode = c.String(),
                        DepartureTime = c.DateTime(nullable: false),
                        ArrivalTime = c.DateTime(nullable: false),
                        ArrivingToCity_CityID = c.Int(),
                        DepartingFromCity_CityID = c.Int(),
                    })
                .PrimaryKey(t => t.FlightID)
                .ForeignKey("dbo.RACS_Cities", t => t.ArrivingToCity_CityID)
                .ForeignKey("dbo.RACS_Cities", t => t.DepartingFromCity_CityID)
                .Index(t => t.ArrivingToCity_CityID)
                .Index(t => t.DepartingFromCity_CityID);
            
            DropTable("dbo.RACS_Flights");
            DropTable("dbo.CitiesFlights");
            DropTable("dbo.CitiesFlight1");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CitiesFlight1",
                c => new
                    {
                        Cities_CityID = c.Int(nullable: false),
                        Flight_FlightID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Cities_CityID, t.Flight_FlightID });
            
            CreateTable(
                "dbo.CitiesFlights",
                c => new
                    {
                        Cities_CityID = c.Int(nullable: false),
                        Flight_FlightID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Cities_CityID, t.Flight_FlightID });
            
            CreateTable(
                "dbo.RACS_Flights",
                c => new
                    {
                        FlightID = c.Int(nullable: false, identity: true),
                        FlightCode = c.String(),
                        DepatureTime = c.DateTime(nullable: false),
                        ArrivalTime = c.DateTime(nullable: false),
                        IsFull = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.FlightID);
            
            DropForeignKey("dbo.Flights", "DepartingFromCity_CityID", "dbo.RACS_Cities");
            DropForeignKey("dbo.Flights", "ArrivingToCity_CityID", "dbo.RACS_Cities");
            DropIndex("dbo.Flights", new[] { "DepartingFromCity_CityID" });
            DropIndex("dbo.Flights", new[] { "ArrivingToCity_CityID" });
            DropTable("dbo.Flights");
            CreateIndex("dbo.CitiesFlight1", "Flight_FlightID");
            CreateIndex("dbo.CitiesFlight1", "Cities_CityID");
            CreateIndex("dbo.CitiesFlights", "Flight_FlightID");
            CreateIndex("dbo.CitiesFlights", "Cities_CityID");
            AddForeignKey("dbo.CitiesFlight1", "Flight_FlightID", "dbo.RACS_Flights", "FlightID", cascadeDelete: true);
            AddForeignKey("dbo.CitiesFlight1", "Cities_CityID", "dbo.RACS_Cities", "CityID", cascadeDelete: true);
            AddForeignKey("dbo.CitiesFlights", "Flight_FlightID", "dbo.RACS_Flights", "FlightID", cascadeDelete: true);
            AddForeignKey("dbo.CitiesFlights", "Cities_CityID", "dbo.RACS_Cities", "CityID", cascadeDelete: true);
        }
    }
}
