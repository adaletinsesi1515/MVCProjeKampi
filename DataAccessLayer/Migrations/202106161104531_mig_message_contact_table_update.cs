namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_message_contact_table_update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "IsDraft", c => c.Boolean(nullable: false));
            AddColumn("dbo.Messages", "IsRead", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Messages", "MessageContent", c => c.String());
            DropColumn("dbo.Contacts", "ContactStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "ContactStatus", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Messages", "MessageContent", c => c.String(maxLength: 1000));
            DropColumn("dbo.Messages", "IsRead");
            DropColumn("dbo.Messages", "IsDraft");
        }
    }
}
