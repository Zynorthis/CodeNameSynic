namespace CodeNameSynic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HomeInit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        UserPreferences_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.UserPreferences", t => t.UserPreferences_ID)
                .Index(t => t.UserPreferences_ID);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Address = c.String(),
                        Latitude = c.Single(nullable: false),
                        Longitude = c.Single(nullable: false),
                        StartTime = c.Int(nullable: false),
                        EndTime = c.Int(nullable: false),
                        TotalRating = c.Double(nullable: false),
                        UserRefId = c.Int(),
                        CategoryRefId = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoryRefId)
                .ForeignKey("dbo.SynicUsers", t => t.UserRefId)
                .Index(t => t.UserRefId)
                .Index(t => t.CategoryRefId);
            
            CreateTable(
                "dbo.SynicUsers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        ApplicationUserRefId = c.String(maxLength: 128),
                        UserPreferencesRefId = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserRefId)
                .ForeignKey("dbo.UserPreferences", t => t.UserPreferencesRefId)
                .Index(t => t.ApplicationUserRefId)
                .Index(t => t.UserPreferencesRefId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.UserPreferences",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SendEmail = c.Boolean(nullable: false),
                        SendText = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RatingNumber = c.Int(nullable: false),
                        Description = c.String(),
                        EventRefId = c.Int(),
                        SynicUserRefId = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Events", t => t.EventRefId)
                .ForeignKey("dbo.SynicUsers", t => t.SynicUserRefId)
                .Index(t => t.EventRefId)
                .Index(t => t.SynicUserRefId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Ratings", "SynicUserRefId", "dbo.SynicUsers");
            DropForeignKey("dbo.Ratings", "EventRefId", "dbo.Events");
            DropForeignKey("dbo.Events", "UserRefId", "dbo.SynicUsers");
            DropForeignKey("dbo.SynicUsers", "UserPreferencesRefId", "dbo.UserPreferences");
            DropForeignKey("dbo.Categories", "UserPreferences_ID", "dbo.UserPreferences");
            DropForeignKey("dbo.SynicUsers", "ApplicationUserRefId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Events", "CategoryRefId", "dbo.Categories");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Ratings", new[] { "SynicUserRefId" });
            DropIndex("dbo.Ratings", new[] { "EventRefId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.SynicUsers", new[] { "UserPreferencesRefId" });
            DropIndex("dbo.SynicUsers", new[] { "ApplicationUserRefId" });
            DropIndex("dbo.Events", new[] { "CategoryRefId" });
            DropIndex("dbo.Events", new[] { "UserRefId" });
            DropIndex("dbo.Categories", new[] { "UserPreferences_ID" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Ratings");
            DropTable("dbo.UserPreferences");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.SynicUsers");
            DropTable("dbo.Events");
            DropTable("dbo.Categories");
        }
    }
}
