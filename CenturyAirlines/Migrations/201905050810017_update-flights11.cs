namespace CenturyAirlines.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateflights11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RACS_Flights", "DepartingFromCity_CityID", "dbo.RACS_Cities");
            DropIndex("dbo.RACS_Flights", new[] { "DepartingFromCity_CityID" });
            AddColumn("dbo.RACS_Flights", "DepartureCityCode", c => c.String(nullable: false, maxLength: 3));
            AlterColumn("dbo.RACS_Cities", "CityCode", c => c.String(nullable: false, maxLength: 3));
            AlterColumn("dbo.RACS_Flights", "FlightCode", c => c.String(nullable: false, maxLength: 8));
            AlterColumn("dbo.RACS_Flights", "DepartingFromCity_CityID", c => c.Int(nullable: false));
            CreateIndex("dbo.RACS_Flights", "DepartingFromCity_CityID");
            AddForeignKey("dbo.RACS_Flights", "DepartingFromCity_CityID", "dbo.RACS_Cities", "CityID", cascadeDelete: true);
            DropColumn("dbo.RACS_Flights", "SelectedDepartingFromCity");
            DropColumn("dbo.RACS_Flights", "DepartingFromCityIndex");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RACS_Flights", "DepartingFromCityIndex", c => c.Int(nullable: false));
            AddColumn("dbo.RACS_Flights", "SelectedDepartingFromCity", c => c.String(nullable: false));
            DropForeignKey("dbo.RACS_Flights", "DepartingFromCity_CityID", "dbo.RACS_Cities");
            DropIndex("dbo.RACS_Flights", new[] { "DepartingFromCity_CityID" });
            AlterColumn("dbo.RACS_Flights", "DepartingFromCity_CityID", c => c.Int());
            AlterColumn("dbo.RACS_Flights", "FlightCode", c => c.String(nullable: false));
            AlterColumn("dbo.RACS_Cities", "CityCode", c => c.String(nullable: false));
            DropColumn("dbo.RACS_Flights", "DepartureCityCode");
            CreateIndex("dbo.RACS_Flights", "DepartingFromCity_CityID");
            AddForeignKey("dbo.RACS_Flights", "DepartingFromCity_CityID", "dbo.RACS_Cities", "CityID");
        }
    }
}
