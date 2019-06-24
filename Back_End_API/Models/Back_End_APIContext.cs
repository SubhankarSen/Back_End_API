using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Back_End_API.Models
{
    public class Back_End_APIContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public Back_End_APIContext() : base("name=Back_End_APIContext")
        {
        }

        public System.Data.Entity.DbSet<Back_End_API.Models.Project> Projects { get; set; }

        public System.Data.Entity.DbSet<Back_End_API.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<Back_End_API.Models.UserTask> UserTasks { get; set; }

        public System.Data.Entity.DbSet<Back_End_API.Models.ParentTask> ParentTasks { get; set; }
    }
}
