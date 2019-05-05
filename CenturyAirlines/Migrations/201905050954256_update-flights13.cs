namespace CenturyAirlines.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateflights13 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RACS_Flights", "ArrivingToCity_CityID", "dbo.RACS_Cities");
            DropForeignKey("dbo.RACS_Flights", "DepartingFromCity_CityID", "dbo.RACS_Cities");
            DropIndex("dbo.RACS_Flights", new[] { "ArrivingToCity_CityID" });
            DropIndex("dbo.RACS_Flights", new[] { "DepartingFromCity_CityID" });
            RenameColumn(table: "dbo.RACS_Flights", name: "ArrivingToCity_CityID", newName: "ArrivingToCity_CityCode");
            RenameColumn(table: "dbo.RACS_Flights", name: "DepartingFromCity_CityID", newName: "DepartingFromCity_CityCode");
            DropPrimaryKey("dbo.RACS_Cities");
            AlterColumn("dbo.RACS_Cities", "CityID", c => c.Int(nullable: false));
            AlterColumn("dbo.RACS_Cities", "CityName", c => c.String());
            AlterColumn("dbo.RACS_Flights", "ArrivingToCity_CityCode", c => c.String(maxLength: 3));
            AlterColumn("dbo.RACS_Flights", "DepartingFromCity_CityCode", c => c.String(nullable: false, maxLength: 3));
            AddPrimaryKey("dbo.RACS_Cities", "CityCode");
            CreateIndex("dbo.RACS_Flights", "ArrivingToCity_CityCode");
            CreateIndex("dbo.RACS_Flights", "DepartingFromCity_CityCode");
            AddForeignKey("dbo.RACS_Flights", "ArrivingToCity_CityCode", "dbo.RACS_Cities", "CityCode");
            AddForeignKey("dbo.RACS_Flights", "DepartingFromCity_CityCode", "dbo.RACS_Cities", "CityCode", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RACS_Flights", "DepartingFromCity_CityCode", "dbo.RACS_Cities");
            DropForeignKey("dbo.RACS_Flights", "ArrivingToCity_CityCode", "dbo.RACS_Cities");
            DropIndex("dbo.RACS_Flights", new[] { "DepartingFromCity_CityCode" });
            DropIndex("dbo.RACS_Flights", new[] { "ArrivingToCity_CityCode" });
            DropPrimaryKey("dbo.RACS_Cities");
            AlterColumn("dbo.RACS_Flights", "DepartingFromCity_CityCode", c => c.Int(nullable: false));
            AlterColumn("dbo.RACS_Flights", "ArrivingToCity_CityCode", c => c.Int());
            AlterColumn("dbo.RACS_Cities", "CityName", c => c.String(nullable: false));
            AlterColumn("dbo.RACS_Cities", "CityID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.RACS_Cities", "CityID");
            RenameColumn(table: "dbo.RACS_Flights", name: "DepartingFromCity_CityCode", newName: "DepartingFromCity_CityID");
            RenameColumn(table: "dbo.RACS_Flights", name: "ArrivingToCity_CityCode", newName: "ArrivingToCity_CityID");
            CreateIndex("dbo.RACS_Flights", "DepartingFromCity_CityID");
            CreateIndex("dbo.RACS_Flights", "ArrivingToCity_CityID");
            AddForeignKey("dbo.RACS_Flights", "DepartingFromCity_CityID", "dbo.RACS_Cities", "CityID", cascadeDelete: true);
            AddForeignKey("dbo.RACS_Flights", "ArrivingToCity_CityID", "dbo.RACS_Cities", "CityID");
        }
    }
}
