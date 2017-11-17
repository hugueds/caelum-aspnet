namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionacampoPublicadoemPost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Publicado", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Publicado");
        }
    }
}
