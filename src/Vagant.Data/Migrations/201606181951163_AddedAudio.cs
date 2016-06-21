namespace Vagant.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAudio : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "AudioId", c => c.Int());
            CreateIndex("dbo.Events", "AudioId");
            AddForeignKey("dbo.Events", "AudioId", "dbo.FileDatas", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "AudioId", "dbo.FileDatas");
            DropIndex("dbo.Events", new[] { "AudioId" });
            DropColumn("dbo.Events", "AudioId");
        }
    }
}
