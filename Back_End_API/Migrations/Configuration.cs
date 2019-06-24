namespace Back_End_API.Migrations
{
    using Back_End_API.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Back_End_APIContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Back_End_APIContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.ParentTasks.AddOrUpdate(
                new ParentTask() { ParentTaskID = 1, ParentTask_Desc = "Admin Task 1" },
                new ParentTask() { ParentTaskID = 2, ParentTask_Desc = "Admin Task 2" }
                );
            context.Projects.AddOrUpdate(
                new Project() { ProjectID = 1, Project_Desc = "Admin Project 1", ProjStart_Date = Convert.ToDateTime("1980-01-01"), ProjEnd_Date = Convert.ToDateTime("1980-12-01"), Proj_Priority = 99, UserID = 1, UserTasks = new List<UserTask>() },
                new Project() { ProjectID = 2, Project_Desc = "Admin Project 2", ProjStart_Date = Convert.ToDateTime("1981-01-01"), ProjEnd_Date = Convert.ToDateTime("1981-12-01"), Proj_Priority = 98, UserID = 2, UserTasks = new List<UserTask>() }
                );
            context.Users.AddOrUpdate(
                new User() { UserID = 1, UserFirstName = "AdminFN1", UserLastName = "AdminLN1", UserEmployeeID = 999999 },
                new User() { UserID = 2, UserFirstName = "AdminFN2", UserLastName = "AdminLN2", UserEmployeeID = 999998 }
                );
            context.UserTasks.AddOrUpdate(
                new UserTask() { UserTaskID = 1, ParentTaskID = 1, ProjectID = 1, Task_Desc = "User Task 1", TaskStart_Date = Convert.ToDateTime("1983-12-02"), TaskEnd_Date = Convert.ToDateTime("1984-11-03"), Task_Status = true, Task_Priority = 99, UserID = 2 },
                new UserTask() { UserTaskID = 2, ParentTaskID = 2, ProjectID = 2, Task_Desc = "User Task 2", TaskStart_Date = Convert.ToDateTime("1985-11-02"), TaskEnd_Date = Convert.ToDateTime("1986-10-03"), Task_Status = true, Task_Priority = 98, UserID = 1 }
                );
        }
    }
}
