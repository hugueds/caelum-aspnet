namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Timestamp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Timestamp", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Timestamp");
        }
    }
}
