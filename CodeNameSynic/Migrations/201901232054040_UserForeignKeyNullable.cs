namespace CodeNameSynic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserForeignKeyNullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SynicUsers", "UserPreferencesRefId", "dbo.UserPreferences");
            DropIndex("dbo.SynicUsers", new[] { "UserPreferencesRefId" });
            AlterColumn("dbo.SynicUsers", "UserPreferencesRefId", c => c.Int());
            CreateIndex("dbo.SynicUsers", "UserPreferencesRefId");
            AddForeignKey("dbo.SynicUsers", "UserPreferencesRefId", "dbo.UserPreferences", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SynicUsers", "UserPreferencesRefId", "dbo.UserPreferences");
            DropIndex("dbo.SynicUsers", new[] { "UserPreferencesRefId" });
            AlterColumn("dbo.SynicUsers", "UserPreferencesRefId", c => c.Int(nullable: false));
            CreateIndex("dbo.SynicUsers", "UserPreferencesRefId");
            AddForeignKey("dbo.SynicUsers", "UserPreferencesRefId", "dbo.UserPreferences", "ID", cascadeDelete: true);
        }
    }
}
