namespace Vagant.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageFileToFileData : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ImageFiles", newName: "FileDatas");
            DropForeignKey("dbo.EventImages", "EventId", "dbo.Events");
            DropForeignKey("dbo.EventImages", "ImageFileId", "dbo.ImageFiles");
            DropIndex("dbo.EventImages", new[] { "ImageFileId" });
            DropIndex("dbo.EventImages", new[] { "EventId" });
            DropTable("dbo.EventImages");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.EventImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageFileId = c.Int(nullable: false),
                        EventId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.EventImages", "EventId");
            CreateIndex("dbo.EventImages", "ImageFileId");
            AddForeignKey("dbo.EventImages", "ImageFileId", "dbo.ImageFiles", "Id");
            AddForeignKey("dbo.EventImages", "EventId", "dbo.Events", "Id");
            RenameTable(name: "dbo.FileDatas", newName: "ImageFiles");
        }
    }
}
