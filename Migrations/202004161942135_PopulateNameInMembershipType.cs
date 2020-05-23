namespace VidlyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateNameInMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name = 'PayAsYouGo' WHERE Id = 1");
            Sql("UPDATE MembershipTypes SET Name = 'Monthly' WHERE Id = 2");
            Sql("UPDATE MembershipTypes SET Name = 'Quarterly' WHERE Id = 3");
            Sql("UPDATE MembershipTypes SET Name = 'Annual' WHERE Id = 4");

            //Sql("INSERT INTO MembershipTypes (Id, Name) VALUES(1, 'PayAsYouGo')");
            //Sql("INSERT INTO MembershipTypes (Id, Name) VALUES(2, 'Monthly')");
            //Sql("INSERT INTO MembershipTypes (Id, Name) VALUES(3, 'Quarterly')");
            //Sql("INSERT INTO MembershipTypes (Id, Name) VALUES(4, 'Annual')");

        }
        
        public override void Down()
        {
        }
    }
}
