namespace VidlyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGender : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Name) VALUES('Action')");
            Sql("INSERT INTO Genres (Name) VALUES('Romance')");
            Sql("INSERT INTO Genres (Name) VALUES('Thriller')");
            Sql("INSERT INTO Genres (Name) VALUES('Comedy')");
            Sql("INSERT INTO Genres (Name) VALUES('Crime')");
            Sql("INSERT INTO Genres (Name) VALUES('Horror')");
            Sql("INSERT INTO Genres (Name) VALUES('Western')");
            Sql("INSERT INTO Genres (Name) VALUES('Family')");
        }
        
        public override void Down()
        {
        }
    }
}
