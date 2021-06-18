namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_AboutTitle_Add : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abouts", "AboutTitle", c => c.String(maxLength: 1000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Abouts", "AboutTitle");
        }
    }
}
