namespace SM.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class restore : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "DateOfBirth", c => c.DateTime());
            AddColumn("dbo.Students", "Gender", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Gender");
            DropColumn("dbo.Students", "DateOfBirth");
        }
    }
}
