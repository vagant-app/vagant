namespace Vagant.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FullSchema : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.AspNetUsers", name: "Avatar_Id", newName: "AvatarId");
            RenameColumn(table: "dbo.AspNetUsers", name: "ContactInfo_Id", newName: "ContactInfoId");
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_Avatar_Id", newName: "IX_AvatarId");
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_ContactInfo_Id", newName: "IX_ContactInfoId");
            CreateTable(
                "dbo.EventComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        EventId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .Index(t => t.EventId);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        BriefDescription = c.String(),
                        FullDescription = c.String(),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(),
                        Rate = c.Double(nullable: false),
                        VotesNumber = c.Int(nullable: false),
                        LocationId = c.Int(nullable: false),
                        LogoId = c.Int(nullable: false),
                        AuthorId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AuthorId)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .ForeignKey("dbo.ImageFiles", t => t.LogoId, cascadeDelete: true)
                .Index(t => t.LocationId)
                .Index(t => t.LogoId)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        DisplayName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EventImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageFileId = c.Int(nullable: false),
                        EventId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.EventId)
                .ForeignKey("dbo.ImageFiles", t => t.ImageFileId)
                .Index(t => t.ImageFileId)
                .Index(t => t.EventId);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AuthorId = c.String(maxLength: 128),
                        RecipientId = c.String(maxLength: 128),
                        Text = c.String(),
                        IsRead = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AuthorId)
                .ForeignKey("dbo.AspNetUsers", t => t.RecipientId)
                .Index(t => t.AuthorId)
                .Index(t => t.RecipientId);
            
            CreateTable(
                "dbo.Visitors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        EventId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.EventId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Visitors", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Visitors", "EventId", "dbo.Events");
            DropForeignKey("dbo.Messages", "RecipientId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "AuthorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.EventImages", "ImageFileId", "dbo.ImageFiles");
            DropForeignKey("dbo.EventImages", "EventId", "dbo.Events");
            DropForeignKey("dbo.EventComments", "EventId", "dbo.Events");
            DropForeignKey("dbo.Events", "LogoId", "dbo.ImageFiles");
            DropForeignKey("dbo.Events", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.Events", "AuthorId", "dbo.AspNetUsers");
            DropIndex("dbo.Visitors", new[] { "EventId" });
            DropIndex("dbo.Visitors", new[] { "UserId" });
            DropIndex("dbo.Messages", new[] { "RecipientId" });
            DropIndex("dbo.Messages", new[] { "AuthorId" });
            DropIndex("dbo.EventImages", new[] { "EventId" });
            DropIndex("dbo.EventImages", new[] { "ImageFileId" });
            DropIndex("dbo.Events", new[] { "AuthorId" });
            DropIndex("dbo.Events", new[] { "LogoId" });
            DropIndex("dbo.Events", new[] { "LocationId" });
            DropIndex("dbo.EventComments", new[] { "EventId" });
            DropTable("dbo.Visitors");
            DropTable("dbo.Messages");
            DropTable("dbo.EventImages");
            DropTable("dbo.Locations");
            DropTable("dbo.Events");
            DropTable("dbo.EventComments");
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_ContactInfoId", newName: "IX_ContactInfo_Id");
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_AvatarId", newName: "IX_Avatar_Id");
            RenameColumn(table: "dbo.AspNetUsers", name: "ContactInfoId", newName: "ContactInfo_Id");
            RenameColumn(table: "dbo.AspNetUsers", name: "AvatarId", newName: "Avatar_Id");
        }
    }
}
