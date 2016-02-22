namespace SimpleApp.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDonorAuditLog : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AuditLog", "Donor_Id", c => c.Int());
            CreateIndex("dbo.AuditLog", "Donor_Id");
            AddForeignKey("dbo.AuditLog", "Donor_Id", "dbo.Donor", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AuditLog", "Donor_Id", "dbo.Donor");
            DropIndex("dbo.AuditLog", new[] { "Donor_Id" });
            DropColumn("dbo.AuditLog", "Donor_Id");
        }
    }
}
