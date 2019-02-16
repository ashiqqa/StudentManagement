namespace SM.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class student_bank_modified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BankAccounts", "Student_Id", c => c.Int());
            AddColumn("dbo.Students", "BankAccount_Id", c => c.Int());
            CreateIndex("dbo.BankAccounts", "Student_Id");
            CreateIndex("dbo.Students", "BankAccount_Id");
            AddForeignKey("dbo.Students", "BankAccount_Id", "dbo.BankAccounts", "Id");
            AddForeignKey("dbo.BankAccounts", "Student_Id", "dbo.Students", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BankAccounts", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.Students", "BankAccount_Id", "dbo.BankAccounts");
            DropIndex("dbo.Students", new[] { "BankAccount_Id" });
            DropIndex("dbo.BankAccounts", new[] { "Student_Id" });
            DropColumn("dbo.Students", "BankAccount_Id");
            DropColumn("dbo.BankAccounts", "Student_Id");
        }
    }
}
