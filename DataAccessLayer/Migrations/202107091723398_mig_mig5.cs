namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_mig5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "AdminStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Admins", "RoleId", c => c.Int());
            DropColumn("dbo.Admins", "AdminRole");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "AdminRole", c => c.String(maxLength: 1));
            DropColumn("dbo.Admins", "RoleId");
            DropColumn("dbo.Admins", "AdminStatus");
        }
    }
}
