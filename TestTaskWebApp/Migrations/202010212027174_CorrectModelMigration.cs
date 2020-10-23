namespace TestTaskWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectModelMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Clients", "Distance");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clients", "Distance", c => c.Double(nullable: false));
        }
    }
}
