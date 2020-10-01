namespace Dialectico.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedStringForRootName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Word", "RootName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Word", "RootName");
        }
    }
}
