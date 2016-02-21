namespace SimpleApp.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMaxLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Donors", "FirstName", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Patients", "FirstName", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Patients", "LastName", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patients", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Patients", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Donors", "FirstName", c => c.String(nullable: false));
        }
    }
}
