namespace Vagant.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageFileChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ImageFiles", "Data", c => c.Binary());
            AddColumn("dbo.ImageFiles", "ContentType", c => c.String());
            DropColumn("dbo.ImageFiles", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ImageFiles", "Date", c => c.Binary());
            DropColumn("dbo.ImageFiles", "ContentType");
            DropColumn("dbo.ImageFiles", "Data");
        }
    }
}
