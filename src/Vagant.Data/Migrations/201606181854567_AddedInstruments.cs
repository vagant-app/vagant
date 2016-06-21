namespace Vagant.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedInstruments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventInstruments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsGuitarUsed = c.Boolean(nullable: false),
                        IsViolinUsed = c.Boolean(nullable: false),
                        IsVocalApplicable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Events", "EventInstrumentId", c => c.Int());
            CreateIndex("dbo.Events", "EventInstrumentId");
            AddForeignKey("dbo.Events", "EventInstrumentId", "dbo.EventInstruments", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "EventInstrumentId", "dbo.EventInstruments");
            DropIndex("dbo.Events", new[] { "EventInstrumentId" });
            DropColumn("dbo.Events", "EventInstrumentId");
            DropTable("dbo.EventInstruments");
        }
    }
}
