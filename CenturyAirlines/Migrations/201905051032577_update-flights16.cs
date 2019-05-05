namespace CenturyAirlines.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateflights16 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RACS_Flights", "ArrivingToCity_CityCode", "dbo.RACS_Cities");
            DropForeignKey("dbo.RACS_Flights", "DepartingFromCity_CityCode", "dbo.RACS_Cities");
            DropIndex("dbo.RACS_Flights", new[] { "ArrivingToCity_CityCode" });
            DropIndex("dbo.RACS_Flights", new[] { "DepartingFromCity_CityCode" });
            RenameColumn(table: "dbo.RACS_Flights", name: "ArrivingToCity_CityCode", newName: "ArrivingToCity_CityID");
            RenameColumn(table: "dbo.RACS_Flights", name: "DepartingFromCity_CityCode", newName: "DepartingFromCity_CityID");
            DropPrimaryKey("dbo.RACS_Cities");
            AddColumn("dbo.RACS_Flights", "DepartureCityID", c => c.Int(nullable: false));
            AlterColumn("dbo.RACS_Cities", "CityID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.RACS_Cities", "CityName", c => c.String(nullable: false));
            AlterColumn("dbo.RACS_Flights", "ArrivingToCity_CityID", c => c.Int());
            AlterColumn("dbo.RACS_Flights", "DepartingFromCity_CityID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.RACS_Cities", "CityID");
            CreateIndex("dbo.RACS_Flights", "ArrivingToCity_CityID");
            CreateIndex("dbo.RACS_Flights", "DepartingFromCity_CityID");
            AddForeignKey("dbo.RACS_Flights", "ArrivingToCity_CityID", "dbo.RACS_Cities", "CityID");
            AddForeignKey("dbo.RACS_Flights", "DepartingFromCity_CityID", "dbo.RACS_Cities", "CityID", cascadeDelete: true);
            DropColumn("dbo.RACS_Flights", "DepartureCityCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RACS_Flights", "DepartureCityCode", c => c.String(nullable: false, maxLength: 3));
            DropForeignKey("dbo.RACS_Flights", "DepartingFromCity_CityID", "dbo.RACS_Cities");
            DropForeignKey("dbo.RACS_Flights", "ArrivingToCity_CityID", "dbo.RACS_Cities");
            DropIndex("dbo.RACS_Flights", new[] { "DepartingFromCity_CityID" });
            DropIndex("dbo.RACS_Flights", new[] { "ArrivingToCity_CityID" });
            DropPrimaryKey("dbo.RACS_Cities");
            AlterColumn("dbo.RACS_Flights", "DepartingFromCity_CityID", c => c.String(nullable: false, maxLength: 3));
            AlterColumn("dbo.RACS_Flights", "ArrivingToCity_CityID", c => c.String(maxLength: 3));
            AlterColumn("dbo.RACS_Cities", "CityName", c => c.String());
            AlterColumn("dbo.RACS_Cities", "CityID", c => c.Int(nullable: false));
            DropColumn("dbo.RACS_Flights", "DepartureCityID");
            AddPrimaryKey("dbo.RACS_Cities", "CityCode");
            RenameColumn(table: "dbo.RACS_Flights", name: "DepartingFromCity_CityID", newName: "DepartingFromCity_CityCode");
            RenameColumn(table: "dbo.RACS_Flights", name: "ArrivingToCity_CityID", newName: "ArrivingToCity_CityCode");
            CreateIndex("dbo.RACS_Flights", "DepartingFromCity_CityCode");
            CreateIndex("dbo.RACS_Flights", "ArrivingToCity_CityCode");
            AddForeignKey("dbo.RACS_Flights", "DepartingFromCity_CityCode", "dbo.RACS_Cities", "CityCode", cascadeDelete: true);
            AddForeignKey("dbo.RACS_Flights", "ArrivingToCity_CityCode", "dbo.RACS_Cities", "CityCode");
        }
    }
}
