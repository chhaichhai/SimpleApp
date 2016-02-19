using System.Data.Entity.Migrations;

namespace SimpleApp.DataLayer.Migrations
{
    public partial class AddedTestData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DOB = c.String(),
                        Sex = c.String(),
                        Insurance = c.Boolean(nullable: false),
                        CaliforniaResident = c.Boolean(nullable: false),
                        EmploymentStatus = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Patients");
        }
    }
}
