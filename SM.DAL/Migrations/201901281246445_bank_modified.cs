namespace SM.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bank_modified : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "BankAccount_Id", "dbo.BankAccounts");
            DropForeignKey("dbo.BankAccounts", "Student_Id", "dbo.Students");
            DropIndex("dbo.BankAccounts", new[] { "Student_Id" });
            DropIndex("dbo.Students", new[] { "BankAccount_Id" });
            DropColumn("dbo.BankAccounts", "Student_Id");
            DropColumn("dbo.Students", "BankAccount_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "BankAccount_Id", c => c.Int());
            AddColumn("dbo.BankAccounts", "Student_Id", c => c.Int());
            CreateIndex("dbo.Students", "BankAccount_Id");
            CreateIndex("dbo.BankAccounts", "Student_Id");
            AddForeignKey("dbo.BankAccounts", "Student_Id", "dbo.Students", "Id");
            AddForeignKey("dbo.Students", "BankAccount_Id", "dbo.BankAccounts", "Id");
        }
    }
}
