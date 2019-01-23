namespace CodeNameSynic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbAddTableUserPref : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserPreferences",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SendEmail = c.Boolean(nullable: false),
                        SendText = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Categories", "UserPreferences_ID", c => c.Int());
            AddColumn("dbo.SynicUsers", "UserPreferencesRefId", c => c.Int(nullable: false));
            CreateIndex("dbo.Categories", "UserPreferences_ID");
            CreateIndex("dbo.SynicUsers", "UserPreferencesRefId");
            AddForeignKey("dbo.Categories", "UserPreferences_ID", "dbo.UserPreferences", "ID");
            AddForeignKey("dbo.SynicUsers", "UserPreferencesRefId", "dbo.UserPreferences", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SynicUsers", "UserPreferencesRefId", "dbo.UserPreferences");
            DropForeignKey("dbo.Categories", "UserPreferences_ID", "dbo.UserPreferences");
            DropIndex("dbo.SynicUsers", new[] { "UserPreferencesRefId" });
            DropIndex("dbo.Categories", new[] { "UserPreferences_ID" });
            DropColumn("dbo.SynicUsers", "UserPreferencesRefId");
            DropColumn("dbo.Categories", "UserPreferences_ID");
            DropTable("dbo.UserPreferences");
        }
    }
}
