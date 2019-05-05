namespace CenturyAirlines.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatemigration2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RACS_Cities", "CityName", c => c.String(nullable: false));
            AlterColumn("dbo.RACS_Cities", "CityCode", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RACS_Cities", "CityCode", c => c.String());
            AlterColumn("dbo.RACS_Cities", "CityName", c => c.String());
        }
    }
}
