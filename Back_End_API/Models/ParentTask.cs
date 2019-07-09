using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Back_End_API.Models
{
    public class ParentTask
    {
        public int ParentTaskID { get; set; }

        [Required]
        [StringLength(50)]
        public string ParentTaskDesc { get; set; }

        //public virtual ICollection<UserTask> UserTasks { get; set; }
    }
}