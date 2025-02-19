namespace AcunMedya.Restaurantly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "Name", c => c.String());
            AddColumn("dbo.Admins", "SurName", c => c.String());
            AddColumn("dbo.Admins", "ImageUrl", c => c.String());
            AddColumn("dbo.Admins", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "Email");
            DropColumn("dbo.Admins", "ImageUrl");
            DropColumn("dbo.Admins", "SurName");
            DropColumn("dbo.Admins", "Name");
        }
    }
}
