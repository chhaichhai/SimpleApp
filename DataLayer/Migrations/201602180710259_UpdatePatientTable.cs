namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePatientTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "FirstName", c => c.String());
            AddColumn("dbo.Patients", "LastName", c => c.String());
            AddColumn("dbo.Patients", "DOB", c => c.String());
            AddColumn("dbo.Patients", "Sex", c => c.String());
            AddColumn("dbo.Patients", "Insurance", c => c.Boolean(nullable: false));
            AddColumn("dbo.Patients", "CaliforniaResident", c => c.Boolean(nullable: false));
            AddColumn("dbo.Patients", "EmploymentStatus", c => c.String());
            DropColumn("dbo.Patients", "Name");
            DropColumn("dbo.Patients", "Age");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Patients", "Age", c => c.Int(nullable: false));
            AddColumn("dbo.Patients", "Name", c => c.String());
            DropColumn("dbo.Patients", "EmploymentStatus");
            DropColumn("dbo.Patients", "CaliforniaResident");
            DropColumn("dbo.Patients", "Insurance");
            DropColumn("dbo.Patients", "Sex");
            DropColumn("dbo.Patients", "DOB");
            DropColumn("dbo.Patients", "LastName");
            DropColumn("dbo.Patients", "FirstName");
        }
    }
}
