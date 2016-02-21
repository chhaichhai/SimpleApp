namespace SimpleApp.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedSexType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Patients", "Sex", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patients", "Sex", c => c.String());
        }
    }
}
