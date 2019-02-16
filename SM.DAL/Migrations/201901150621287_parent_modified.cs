namespace SM.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class parent_modified : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Images", "StudentId", "dbo.Students");
            DropIndex("dbo.Images", new[] { "StudentId" });
            DropColumn("dbo.Images", "StudentId");
            DropColumn("dbo.Parents", "StudentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Parents", "StudentId", c => c.Int(nullable: false));
            AddColumn("dbo.Images", "StudentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Images", "StudentId");
            AddForeignKey("dbo.Images", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
        }
    }
}
