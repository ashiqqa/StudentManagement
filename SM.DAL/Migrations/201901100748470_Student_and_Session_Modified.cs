namespace SM.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Student_and_Session_Modified : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sesions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Students", "SesionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Students", "SesionId");
            AddForeignKey("dbo.Students", "SesionId", "dbo.Sesions", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "SesionId", "dbo.Sesions");
            DropIndex("dbo.Students", new[] { "SesionId" });
            DropColumn("dbo.Students", "SesionId");
            DropTable("dbo.Sesions");
        }
    }
}
