namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_mig51 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Admins", "RoleId", "dbo.Roles");
            DropIndex("dbo.Admins", new[] { "RoleId" });
            AddColumn("dbo.Admins", "AdminPassword", c => c.String(maxLength: 50));
            AddColumn("dbo.Admins", "AdminRole", c => c.String(maxLength: 1));
            DropColumn("dbo.Admins", "AdminMail");
            DropColumn("dbo.Admins", "AdminPasswordHash");
            DropColumn("dbo.Admins", "AdminPasswordSalt");
            DropColumn("dbo.Admins", "AdminStatus");
            DropColumn("dbo.Admins", "RoleId");
            DropTable("dbo.Roles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(maxLength: 1),
                        Description = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.RoleId);
            
            AddColumn("dbo.Admins", "RoleId", c => c.Int());
            AddColumn("dbo.Admins", "AdminStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Admins", "AdminPasswordSalt", c => c.Binary());
            AddColumn("dbo.Admins", "AdminPasswordHash", c => c.Binary());
            AddColumn("dbo.Admins", "AdminMail", c => c.Binary());
            DropColumn("dbo.Admins", "AdminRole");
            DropColumn("dbo.Admins", "AdminPassword");
            CreateIndex("dbo.Admins", "RoleId");
            AddForeignKey("dbo.Admins", "RoleId", "dbo.Roles", "RoleId");
        }
    }
}
