namespace VidlyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddErrorsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Errors",
                c => new
                    {
                        ErrorId = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        StackTrace = c.String(),
                    })
                .PrimaryKey(t => t.ErrorId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Errors");
        }
    }
}
