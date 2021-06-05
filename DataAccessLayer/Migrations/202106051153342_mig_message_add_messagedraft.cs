namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_message_add_messagedraft : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "MessageDraft", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "MessageDraft");
        }
    }
}
