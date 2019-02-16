namespace SM.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class user_name_modified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserNameOrContact", c => c.String());
            DropColumn("dbo.Users", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Name", c => c.String());
            DropColumn("dbo.Users", "UserNameOrContact");
        }
    }
}
