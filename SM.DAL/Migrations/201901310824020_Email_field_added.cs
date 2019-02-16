namespace SM.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Email_field_added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Email");
        }
    }
}
