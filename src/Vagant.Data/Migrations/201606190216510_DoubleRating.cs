namespace Vagant.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DoubleRating : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EventRatings", "RatingValue", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EventRatings", "RatingValue", c => c.Int(nullable: false));
        }
    }
}
