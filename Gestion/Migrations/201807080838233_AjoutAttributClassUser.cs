namespace Gestion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjoutAttributClassUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Adress", c => c.String());
            AddColumn("dbo.Users", "Tel", c => c.String());
            AddColumn("dbo.Users", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Email");
            DropColumn("dbo.Users", "Tel");
            DropColumn("dbo.Users", "Adress");
        }
    }
}
