namespace Vagant.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rating : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventRatings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VoterId = c.String(maxLength: 128),
                        EventId = c.Int(nullable: false),
                        RatingValue = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.VoterId)
                .Index(t => t.VoterId)
                .Index(t => t.EventId);
            
            AddColumn("dbo.EventComments", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.EventComments", "UserId");
            AddForeignKey("dbo.EventComments", "UserId", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Events", "VotesNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "VotesNumber", c => c.Int(nullable: false));
            DropForeignKey("dbo.EventComments", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.EventRatings", "VoterId", "dbo.AspNetUsers");
            DropForeignKey("dbo.EventRatings", "EventId", "dbo.Events");
            DropIndex("dbo.EventRatings", new[] { "EventId" });
            DropIndex("dbo.EventRatings", new[] { "VoterId" });
            DropIndex("dbo.EventComments", new[] { "UserId" });
            DropColumn("dbo.EventComments", "UserId");
            DropTable("dbo.EventRatings");
        }
    }
}
