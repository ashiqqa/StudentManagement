namespace SM.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateOfBirth_added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "DateOfBirth", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "DateOfBirth");
        }
    }
}
