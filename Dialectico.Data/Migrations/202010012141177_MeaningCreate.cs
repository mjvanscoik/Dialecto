namespace Dialectico.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MeaningCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Meaning", "RegionalDialect", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Meaning", "RegionalDialect");
        }
    }
}
