namespace Back_End_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ParentTasks",
                c => new
                    {
                        ParentTaskID = c.Int(nullable: false, identity: true),
                        ParentTask_Desc = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ParentTaskID);
            
            CreateTable(
                "dbo.UserTasks",
                c => new
                    {
                        UserTaskID = c.Int(nullable: false, identity: true),
                        Task_Desc = c.String(),
                        TaskStart_Date = c.DateTime(nullable: false),
                        TaskEnd_Date = c.DateTime(nullable: false),
                        Task_Priority = c.Int(nullable: false),
                        Task_Status = c.Boolean(nullable: false),
                        ProjectID = c.Int(nullable: false),
                        ParentTaskID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserTaskID)
                .ForeignKey("dbo.ParentTasks", t => t.ParentTaskID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .ForeignKey("dbo.Projects", t => t.ProjectID)
                .Index(t => t.ProjectID)
                .Index(t => t.ParentTaskID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectID = c.Int(nullable: false, identity: true),
                        Project_Desc = c.String(nullable: false, maxLength: 50),
                        ProjStart_Date = c.DateTime(nullable: false),
                        ProjEnd_Date = c.DateTime(nullable: false),
                        Proj_Priority = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserFirstName = c.String(nullable: false, maxLength: 50),
                        UserLastName = c.String(nullable: false, maxLength: 50),
                        UserEmployeeID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserTasks", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.Projects", "UserID", "dbo.Users");
            DropForeignKey("dbo.UserTasks", "UserID", "dbo.Users");
            DropForeignKey("dbo.UserTasks", "ParentTaskID", "dbo.ParentTasks");
            DropIndex("dbo.Projects", new[] { "UserID" });
            DropIndex("dbo.UserTasks", new[] { "UserID" });
            DropIndex("dbo.UserTasks", new[] { "ParentTaskID" });
            DropIndex("dbo.UserTasks", new[] { "ProjectID" });
            DropTable("dbo.Users");
            DropTable("dbo.Projects");
            DropTable("dbo.UserTasks");
            DropTable("dbo.ParentTasks");
        }
    }
}
