namespace SM.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Image_mapped : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Images", "StudentId", "dbo.Students");
            DropIndex("dbo.Images", new[] { "StudentId" });
            AddColumn("dbo.Images", "Student_Id", c => c.Int());
            AddColumn("dbo.Students", "Image_Id", c => c.Int());
            CreateIndex("dbo.Images", "Student_Id");
            CreateIndex("dbo.Students", "Image_Id");
            AddForeignKey("dbo.Students", "Image_Id", "dbo.Images", "Id");
            AddForeignKey("dbo.Images", "Student_Id", "dbo.Students", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.Students", "Image_Id", "dbo.Images");
            DropIndex("dbo.Students", new[] { "Image_Id" });
            DropIndex("dbo.Images", new[] { "Student_Id" });
            DropColumn("dbo.Students", "Image_Id");
            DropColumn("dbo.Images", "Student_Id");
            CreateIndex("dbo.Images", "StudentId");
            AddForeignKey("dbo.Images", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
        }
    }
}
