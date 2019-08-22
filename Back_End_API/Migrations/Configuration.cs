namespace Back_End_API.Migrations
{
    using Back_End_API.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Back_End_API.Models.Back_End_APIContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Back_End_API.Models.Back_End_APIContext context)
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
                new ParentTask() { ParentTaskID = 1, ParentTaskDesc = "Parent Task 1" },
                new ParentTask() { ParentTaskID = 2, ParentTaskDesc = "Parent Task 2" }
                );
            context.Projects.AddOrUpdate(
                new Project() { ProjectID = 1, ProjectDesc = "Admin Project 1", ProjStartDate = Convert.ToDateTime("1980-01-01"), ProjEndDate = Convert.ToDateTime("1980-12-01"), ProjPriority = 29, UserID = 1 },
                new Project() { ProjectID = 2, ProjectDesc = "Admin Project 2", ProjStartDate = Convert.ToDateTime("1981-01-01"), ProjEndDate = Convert.ToDateTime("1981-12-01"), ProjPriority = 28, UserID = 2 }
                );
            context.Users.AddOrUpdate(
                new User() { UserID = 1, UserFirstName = "AdminFN1", UserLastName = "AdminLN1", UserEmployeeID = 999999 },
                new User() { UserID = 2, UserFirstName = "AdminFN2", UserLastName = "AdminLN2", UserEmployeeID = 999998 }
                );
            context.UserTasks.AddOrUpdate(
                new UserTask() { UserTaskID = 1, ParentTaskID = 2, ProjectID = 1, UserTaskDesc = "User Task 1", UserTaskStartDate = Convert.ToDateTime("1983-12-02"), UserTaskEndDate = Convert.ToDateTime("1984-11-03"), UserTaskStatus = true, UserTaskPriority = 29, UserID = 2 },
                new UserTask() { UserTaskID = 2, ParentTaskID = 1, ProjectID = 2, UserTaskDesc = "User Task 2", UserTaskStartDate = Convert.ToDateTime("1985-11-02"), UserTaskEndDate = Convert.ToDateTime("1986-10-03"), UserTaskStatus = true, UserTaskPriority = 28, UserID = 1 },
                new UserTask() { UserTaskID = 3, ParentTaskID = 2, ProjectID = 2, UserTaskDesc = "User Task 3", UserTaskStartDate = Convert.ToDateTime("1986-12-02"), UserTaskEndDate = Convert.ToDateTime("1987-01-03"), UserTaskStatus = true, UserTaskPriority = 27, UserID = 1 },
                new UserTask() { UserTaskID = 4, ParentTaskID = 1, ProjectID = 1, UserTaskDesc = "User Task 4", UserTaskStartDate = Convert.ToDateTime("1986-09-02"), UserTaskEndDate = Convert.ToDateTime("1986-10-03"), UserTaskStatus = false, UserTaskPriority = 23, UserID = 2 }
                );
        }
    }
}
