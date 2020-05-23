namespace VidlyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDateTimeToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Errors", "DateOfLogin", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Errors", "DateOfLogin", c => c.DateTime());
        }
    }
}
