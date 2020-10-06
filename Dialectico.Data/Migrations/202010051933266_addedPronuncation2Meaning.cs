namespace Dialectico.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedPronuncation2Meaning : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Meaning", "Pronunciation", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Meaning", "Pronunciation");
        }
    }
}
