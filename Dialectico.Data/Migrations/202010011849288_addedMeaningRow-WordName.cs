namespace Dialectico.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedMeaningRowWordName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Meaning", "WordName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Meaning", "WordName");
        }
    }
}
