namespace SM.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class student_modified1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "Parent_Id", "dbo.Parents");
            DropIndex("dbo.Students", new[] { "Parent_Id" });
            RenameColumn(table: "dbo.Students", name: "Parent_Id", newName: "ParentId");
            AlterColumn("dbo.Students", "ParentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Students", "ParentId");
            AddForeignKey("dbo.Students", "ParentId", "dbo.Parents", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "ParentId", "dbo.Parents");
            DropIndex("dbo.Students", new[] { "ParentId" });
            AlterColumn("dbo.Students", "ParentId", c => c.Int());
            RenameColumn(table: "dbo.Students", name: "ParentId", newName: "Parent_Id");
            CreateIndex("dbo.Students", "Parent_Id");
            AddForeignKey("dbo.Students", "Parent_Id", "dbo.Parents", "Id");
        }
    }
}
