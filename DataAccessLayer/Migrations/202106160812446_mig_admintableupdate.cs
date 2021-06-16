namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_admintableupdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admins", "AdminUserName", c => c.String(maxLength: 20));
            AlterColumn("dbo.Admins", "AdminPassword", c => c.String());
            AlterColumn("dbo.Admins", "AdminRole", c => c.String(maxLength: 1));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Admins", "AdminRole", c => c.String(maxLength: 30));
            AlterColumn("dbo.Admins", "AdminPassword", c => c.String(maxLength: 30));
            AlterColumn("dbo.Admins", "AdminUserName", c => c.String(maxLength: 30));
        }
    }
}
