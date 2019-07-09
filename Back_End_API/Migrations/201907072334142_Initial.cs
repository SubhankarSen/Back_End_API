namespace Back_End_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.UserTasks", new[] { "ParentTaskID" });
            AlterColumn("dbo.UserTasks", "ParentTaskID", c => c.Int());
            CreateIndex("dbo.UserTasks", "ParentTaskID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.UserTasks", new[] { "ParentTaskID" });
            AlterColumn("dbo.UserTasks", "ParentTaskID", c => c.Int(nullable: false));
            CreateIndex("dbo.UserTasks", "ParentTaskID");
        }
    }
}
