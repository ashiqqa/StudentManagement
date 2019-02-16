namespace SM.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Banks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        File = c.Binary(),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StudentIdNo = c.String(),
                        Password = c.String(),
                        DepartmentId = c.Int(nullable: false),
                        SemisterId = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                        Address = c.String(),
                        AccountNo = c.String(),
                        BankId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Banks", t => t.BankId, cascadeDelete: true)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Semisters", t => t.SemisterId, cascadeDelete: true)
                .Index(t => t.DepartmentId)
                .Index(t => t.SemisterId)
                .Index(t => t.CityId)
                .Index(t => t.BankId);
            
            CreateTable(
                "dbo.Semisters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Students", "SemisterId", "dbo.Semisters");
            DropForeignKey("dbo.Students", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Students", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Students", "BankId", "dbo.Banks");
            DropForeignKey("dbo.Cities", "CountryId", "dbo.Countries");
            DropIndex("dbo.Students", new[] { "BankId" });
            DropIndex("dbo.Students", new[] { "CityId" });
            DropIndex("dbo.Students", new[] { "SemisterId" });
            DropIndex("dbo.Students", new[] { "DepartmentId" });
            DropIndex("dbo.Images", new[] { "StudentId" });
            DropIndex("dbo.Cities", new[] { "CountryId" });
            DropTable("dbo.Users");
            DropTable("dbo.Semisters");
            DropTable("dbo.Students");
            DropTable("dbo.Images");
            DropTable("dbo.Departments");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
            DropTable("dbo.Banks");
        }
    }
}
