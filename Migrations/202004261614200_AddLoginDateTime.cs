namespace VidlyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLoginDateTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Errors", "DateOfLogin", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Errors", "DateOfLogin");
        }
    }
}
