namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_version1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "IsDraft", c => c.Boolean(nullable: false));
            AddColumn("dbo.Messages", "IsRead", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Admins", "AdminUserName", c => c.String(maxLength: 20));
            AlterColumn("dbo.Admins", "AdminPassword", c => c.String());
            AlterColumn("dbo.Admins", "AdminRole", c => c.String(maxLength: 1));
            AlterColumn("dbo.Messages", "MessageContent", c => c.String());
            DropColumn("dbo.Contacts", "ContactStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "ContactStatus", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Messages", "MessageContent", c => c.String(maxLength: 1000));
            AlterColumn("dbo.Admins", "AdminRole", c => c.String(maxLength: 30));
            AlterColumn("dbo.Admins", "AdminPassword", c => c.String(maxLength: 30));
            AlterColumn("dbo.Admins", "AdminUserName", c => c.String(maxLength: 30));
            DropColumn("dbo.Messages", "IsRead");
            DropColumn("dbo.Messages", "IsDraft");
        }
    }
}
