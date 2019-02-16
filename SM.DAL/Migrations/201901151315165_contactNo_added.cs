namespace SM.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contactNo_added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "ContactNo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "ContactNo");
        }
    }
}
