namespace Dialectico.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Meaning",
                c => new
                    {
                        MeaningId = c.Int(nullable: false, identity: true),
                        WordId = c.Int(nullable: false),
                        WordName = c.String(),
                        Pronunciation = c.String(),
                        Context = c.String(),
                        Description = c.String(),
                        CumulativeRating = c.Double(),
                        RegionalDialect = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MeaningId)
                .ForeignKey("dbo.Word", t => t.WordId, cascadeDelete: true)
                .Index(t => t.WordId);
            
            CreateTable(
                "dbo.Rating",
                c => new
                    {
                        RatingId = c.Int(nullable: false, identity: true),
                        IndividualRating = c.Int(nullable: false),
                        Comment = c.String(),
                        MeaningId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RatingId)
                .ForeignKey("dbo.Meaning", t => t.MeaningId, cascadeDelete: true)
                .Index(t => t.MeaningId);
            
            CreateTable(
                "dbo.Word",
                c => new
                    {
                        WordId = c.Int(nullable: false, identity: true),
                        WordName = c.String(),
                        RootName = c.String(),
                        Notes = c.String(),
                        RootId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WordId)
                .ForeignKey("dbo.Root", t => t.RootId, cascadeDelete: true)
                .Index(t => t.RootId);
            
            CreateTable(
                "dbo.Root",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RootName = c.String(nullable: false, maxLength: 14),
                        NotesOnRoot = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Meaning", "WordId", "dbo.Word");
            DropForeignKey("dbo.Word", "RootId", "dbo.Root");
            DropForeignKey("dbo.Rating", "MeaningId", "dbo.Meaning");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Word", new[] { "RootId" });
            DropIndex("dbo.Rating", new[] { "MeaningId" });
            DropIndex("dbo.Meaning", new[] { "WordId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Root");
            DropTable("dbo.Word");
            DropTable("dbo.Rating");
            DropTable("dbo.Meaning");
        }
    }
}
