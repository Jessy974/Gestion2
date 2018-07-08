namespace Gestion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modif : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Applications", "UserID", "dbo.Users");
            DropIndex("dbo.Applications", new[] { "UserID" });
            AddColumn("dbo.Applications", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Applications", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Applications", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.Users", "ApplicationID", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "DeletedAt", c => c.DateTime());
            CreateIndex("dbo.Users", "ApplicationID");
            AddForeignKey("dbo.Users", "ApplicationID", "dbo.Applications", "ID", cascadeDelete: true);
            DropColumn("dbo.Applications", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Applications", "UserID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Users", "ApplicationID", "dbo.Applications");
            DropIndex("dbo.Users", new[] { "ApplicationID" });
            DropColumn("dbo.Users", "DeletedAt");
            DropColumn("dbo.Users", "Deleted");
            DropColumn("dbo.Users", "CreatedAt");
            DropColumn("dbo.Users", "ApplicationID");
            DropColumn("dbo.Applications", "DeletedAt");
            DropColumn("dbo.Applications", "Deleted");
            DropColumn("dbo.Applications", "CreatedAt");
            CreateIndex("dbo.Applications", "UserID");
            AddForeignKey("dbo.Applications", "UserID", "dbo.Users", "ID", cascadeDelete: true);
        }
    }
}
