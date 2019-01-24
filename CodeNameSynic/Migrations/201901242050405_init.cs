namespace CodeNameSynic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Events", "RatingRefId", "dbo.Ratings");
            DropForeignKey("dbo.Events", "CategoryRefId", "dbo.Categories");
            DropForeignKey("dbo.Events", "UserRefId", "dbo.SynicUsers");
            DropIndex("dbo.Events", new[] { "RatingRefId" });
            DropIndex("dbo.Events", new[] { "UserRefId" });
            DropIndex("dbo.Events", new[] { "CategoryRefId" });
            AddColumn("dbo.Ratings", "EventRefId", c => c.Int());
            AddColumn("dbo.Ratings", "SynicUserRefId", c => c.Int());
            AlterColumn("dbo.Events", "UserRefId", c => c.Int());
            AlterColumn("dbo.Events", "CategoryRefId", c => c.Int());
            CreateIndex("dbo.Events", "UserRefId");
            CreateIndex("dbo.Events", "CategoryRefId");
            CreateIndex("dbo.Ratings", "EventRefId");
            CreateIndex("dbo.Ratings", "SynicUserRefId");
            AddForeignKey("dbo.Ratings", "EventRefId", "dbo.Events", "ID");
            AddForeignKey("dbo.Ratings", "SynicUserRefId", "dbo.SynicUsers", "ID");
            AddForeignKey("dbo.Events", "CategoryRefId", "dbo.Categories", "ID");
            AddForeignKey("dbo.Events", "UserRefId", "dbo.SynicUsers", "ID");
            DropColumn("dbo.Events", "RatingRefId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "RatingRefId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Events", "UserRefId", "dbo.SynicUsers");
            DropForeignKey("dbo.Events", "CategoryRefId", "dbo.Categories");
            DropForeignKey("dbo.Ratings", "SynicUserRefId", "dbo.SynicUsers");
            DropForeignKey("dbo.Ratings", "EventRefId", "dbo.Events");
            DropIndex("dbo.Ratings", new[] { "SynicUserRefId" });
            DropIndex("dbo.Ratings", new[] { "EventRefId" });
            DropIndex("dbo.Events", new[] { "CategoryRefId" });
            DropIndex("dbo.Events", new[] { "UserRefId" });
            AlterColumn("dbo.Events", "CategoryRefId", c => c.Int(nullable: false));
            AlterColumn("dbo.Events", "UserRefId", c => c.Int(nullable: false));
            DropColumn("dbo.Ratings", "SynicUserRefId");
            DropColumn("dbo.Ratings", "EventRefId");
            CreateIndex("dbo.Events", "CategoryRefId");
            CreateIndex("dbo.Events", "UserRefId");
            CreateIndex("dbo.Events", "RatingRefId");
            AddForeignKey("dbo.Events", "UserRefId", "dbo.SynicUsers", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Events", "CategoryRefId", "dbo.Categories", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Events", "RatingRefId", "dbo.Ratings", "ID", cascadeDelete: true);
        }
    }
}
