namespace _036_MoviesMvcWissen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoviesV08 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "FilePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "FilePath");
        }
    }
}
