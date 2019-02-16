namespace SM.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class student_modified : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Parents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FathersName = c.String(),
                        MothersName = c.String(),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Students", "File", c => c.Binary());
            AddColumn("dbo.Students", "Parent_Id", c => c.Int());
            CreateIndex("dbo.Students", "Parent_Id");
            AddForeignKey("dbo.Students", "Parent_Id", "dbo.Parents", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Parent_Id", "dbo.Parents");
            DropIndex("dbo.Students", new[] { "Parent_Id" });
            DropColumn("dbo.Students", "Parent_Id");
            DropColumn("dbo.Students", "File");
            DropTable("dbo.Parents");
        }
    }
}
