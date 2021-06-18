namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_TalentLevel_add : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TalentLevels",
                c => new
                    {
                        SkillId = c.Int(nullable: false, identity: true),
                        Skill = c.String(maxLength: 30),
                        SkillPoint = c.String(maxLength: 3),
                    })
                .PrimaryKey(t => t.SkillId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TalentLevels");
        }
    }
}
