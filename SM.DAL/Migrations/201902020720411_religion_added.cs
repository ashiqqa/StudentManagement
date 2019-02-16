namespace SM.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class religion_added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Religion", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Religion");
        }
    }
}
