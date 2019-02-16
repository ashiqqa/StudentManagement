namespace SM.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class image_field_modified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "FileName", c => c.String());
            DropColumn("dbo.Images", "File");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Images", "File", c => c.Binary());
            DropColumn("dbo.Images", "FileName");
        }
    }
}
