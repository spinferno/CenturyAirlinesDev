namespace CenturyAirlines.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateflights18 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RACS_Flights", "DepartingFromCity_CityID", "dbo.RACS_Cities");
            DropIndex("dbo.RACS_Flights", new[] { "DepartingFromCity_CityID" });
            AlterColumn("dbo.RACS_Flights", "DepartingFromCity_CityID", c => c.Int());
            CreateIndex("dbo.RACS_Flights", "DepartingFromCity_CityID");
            AddForeignKey("dbo.RACS_Flights", "DepartingFromCity_CityID", "dbo.RACS_Cities", "CityID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RACS_Flights", "DepartingFromCity_CityID", "dbo.RACS_Cities");
            DropIndex("dbo.RACS_Flights", new[] { "DepartingFromCity_CityID" });
            AlterColumn("dbo.RACS_Flights", "DepartingFromCity_CityID", c => c.Int(nullable: false));
            CreateIndex("dbo.RACS_Flights", "DepartingFromCity_CityID");
            AddForeignKey("dbo.RACS_Flights", "DepartingFromCity_CityID", "dbo.RACS_Cities", "CityID", cascadeDelete: true);
        }
    }
}
