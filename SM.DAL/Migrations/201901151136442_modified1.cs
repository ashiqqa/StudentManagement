namespace SM.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modified1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "Image_Id", "dbo.Images");
            DropForeignKey("dbo.Images", "Student_Id", "dbo.Students");
            DropIndex("dbo.Images", new[] { "Student_Id" });
            DropIndex("dbo.Students", new[] { "Image_Id" });
            DropColumn("dbo.Images", "StudentId");
            RenameColumn(table: "dbo.Images", name: "Student_Id", newName: "StudentId");
            AlterColumn("dbo.Images", "StudentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Images", "StudentId");
            AddForeignKey("dbo.Images", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
            DropColumn("dbo.Students", "Image_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Image_Id", c => c.Int());
            DropForeignKey("dbo.Images", "StudentId", "dbo.Students");
            DropIndex("dbo.Images", new[] { "StudentId" });
            AlterColumn("dbo.Images", "StudentId", c => c.Int());
            RenameColumn(table: "dbo.Images", name: "StudentId", newName: "Student_Id");
            AddColumn("dbo.Images", "StudentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Students", "Image_Id");
            CreateIndex("dbo.Images", "Student_Id");
            AddForeignKey("dbo.Images", "Student_Id", "dbo.Students", "Id");
            AddForeignKey("dbo.Students", "Image_Id", "dbo.Images", "Id");
        }
    }
}
