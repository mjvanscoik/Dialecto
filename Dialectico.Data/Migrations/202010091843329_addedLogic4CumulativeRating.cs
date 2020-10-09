namespace Dialectico.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedLogic4CumulativeRating : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Meaning", "CumulativeRating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Meaning", "CumulativeRating", c => c.Double());
        }
    }
}
