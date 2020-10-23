namespace TestTaskWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "Distance", c => c.Double(nullable: false));
            AlterColumn("dbo.Clients", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "Surname", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "PhoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Merchandizes", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Merchandizes", "Name", c => c.String());
            AlterColumn("dbo.Clients", "PhoneNumber", c => c.String());
            AlterColumn("dbo.Clients", "Surname", c => c.String());
            AlterColumn("dbo.Clients", "Name", c => c.String());
            DropColumn("dbo.Clients", "Distance");
        }
    }
}
