namespace SimpleApp.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedSexEnumType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Donor", "Sex", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Donor", "Sex", c => c.String());
        }
    }
}
