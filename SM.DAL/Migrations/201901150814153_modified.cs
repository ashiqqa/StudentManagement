namespace SM.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "StudentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Images", "StudentId");
            AddForeignKey("dbo.Images", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
            DropColumn("dbo.Students", "File");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "File", c => c.Binary());
            DropForeignKey("dbo.Images", "StudentId", "dbo.Students");
            DropIndex("dbo.Images", new[] { "StudentId" });
            DropColumn("dbo.Images", "StudentId");
        }
    }
}
