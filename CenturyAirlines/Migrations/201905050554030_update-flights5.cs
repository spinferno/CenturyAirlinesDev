namespace CenturyAirlines.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateflights5 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Flights", newName: "RACS_Flights");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.RACS_Flights", newName: "Flights");
        }
    }
}
