namespace Vagant.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsSaxophoneUsed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EventInstruments", "IsSaxophoneUsed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EventInstruments", "IsSaxophoneUsed");
        }
    }
}
