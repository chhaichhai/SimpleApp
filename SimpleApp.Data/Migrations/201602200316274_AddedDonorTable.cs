namespace SimpleApp.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDonorTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Donors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Hospital = c.String(),
                        DOB = c.String(),
                        Sex = c.String(),
                        OrganType = c.String(nullable: false),
                        DeathDateTime = c.DateTime(nullable: false),
                        Status = c.String(),
                        Comments = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Donors");
        }
    }
}
