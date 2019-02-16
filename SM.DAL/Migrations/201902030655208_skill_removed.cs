namespace SM.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class skill_removed : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SkillStudents", "Skill_Id", "dbo.Skills");
            DropForeignKey("dbo.SkillStudents", "Student_Id", "dbo.Students");
            DropIndex("dbo.SkillStudents", new[] { "Skill_Id" });
            DropIndex("dbo.SkillStudents", new[] { "Student_Id" });
            DropTable("dbo.Skills");
            DropTable("dbo.SkillStudents");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SkillStudents",
                c => new
                    {
                        Skill_Id = c.Int(nullable: false),
                        Student_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Skill_Id, t.Student_Id });
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        ITskill = c.Int(nullable: false),
                        IsSelected = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.SkillStudents", "Student_Id");
            CreateIndex("dbo.SkillStudents", "Skill_Id");
            AddForeignKey("dbo.SkillStudents", "Student_Id", "dbo.Students", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SkillStudents", "Skill_Id", "dbo.Skills", "Id", cascadeDelete: true);
        }
    }
}
