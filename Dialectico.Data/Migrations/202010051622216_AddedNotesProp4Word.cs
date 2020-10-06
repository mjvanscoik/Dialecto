namespace Dialectico.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNotesProp4Word : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Word", "Notes", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Word", "Notes");
        }
    }
}
