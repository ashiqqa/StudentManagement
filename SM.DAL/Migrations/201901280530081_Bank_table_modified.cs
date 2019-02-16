namespace SM.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Bank_table_modified : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "BankId", "dbo.Banks");
            DropIndex("dbo.Students", new[] { "BankId" });
            CreateTable(
                "dbo.BankAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BankId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        AccNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Banks", t => t.BankId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.BankId)
                .Index(t => t.StudentId);
            
            DropColumn("dbo.Students", "BankId");
            DropColumn("dbo.Students", "AccountNo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "AccountNo", c => c.String());
            AddColumn("dbo.Students", "BankId", c => c.Int(nullable: false));
            DropForeignKey("dbo.BankAccounts", "StudentId", "dbo.Students");
            DropForeignKey("dbo.BankAccounts", "BankId", "dbo.Banks");
            DropIndex("dbo.BankAccounts", new[] { "StudentId" });
            DropIndex("dbo.BankAccounts", new[] { "BankId" });
            DropTable("dbo.BankAccounts");
            CreateIndex("dbo.Students", "BankId");
            AddForeignKey("dbo.Students", "BankId", "dbo.Banks", "Id", cascadeDelete: true);
        }
    }
}
