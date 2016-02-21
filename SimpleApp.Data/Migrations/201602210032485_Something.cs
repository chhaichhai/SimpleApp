namespace SimpleApp.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Something : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Donors", "LastName", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Donors", "LastName", c => c.String(nullable: false));
        }
    }
}
