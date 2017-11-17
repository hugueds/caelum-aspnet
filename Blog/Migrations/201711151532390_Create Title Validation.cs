namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTitleValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "Titulo", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "Titulo", c => c.String());
        }
    }
}
