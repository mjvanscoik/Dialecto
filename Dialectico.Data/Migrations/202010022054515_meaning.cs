namespace Dialectico.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class meaning : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Meaning", "RatingId", "dbo.Rating");
            DropIndex("dbo.Meaning", new[] { "RatingId" });
            AddColumn("dbo.Rating", "MeaningId", c => c.Int(nullable: false));
            CreateIndex("dbo.Rating", "MeaningId");
            AddForeignKey("dbo.Rating", "MeaningId", "dbo.Meaning", "MeaningId", cascadeDelete: true);
            DropColumn("dbo.Meaning", "RatingId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Meaning", "RatingId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Rating", "MeaningId", "dbo.Meaning");
            DropIndex("dbo.Rating", new[] { "MeaningId" });
            DropColumn("dbo.Rating", "MeaningId");
            CreateIndex("dbo.Meaning", "RatingId");
            AddForeignKey("dbo.Meaning", "RatingId", "dbo.Rating", "RatingId", cascadeDelete: true);
        }
    }
}
