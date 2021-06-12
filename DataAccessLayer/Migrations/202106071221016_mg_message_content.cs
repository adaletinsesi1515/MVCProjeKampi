﻿namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg_message_content : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Messages", "MessageContent", c => c.String(maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Messages", "MessageContent", c => c.String());
        }
    }
}