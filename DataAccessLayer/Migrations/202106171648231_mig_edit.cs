namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_edit : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TalentLevels", "Skill", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TalentLevels", "Skill", c => c.String(maxLength: 20));
        }
    }
}
