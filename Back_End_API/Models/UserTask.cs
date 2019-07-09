using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Back_End_API.Models
{
    public class UserTask
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserTaskID { get; set; }

        public string UserTaskDesc { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}", ApplyFormatInEditMode = true)]
        public DateTime UserTaskStartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}", ApplyFormatInEditMode = true)]
        public DateTime UserTaskEndDate { get; set; }

        public int UserTaskPriority { get; set; }

        public bool UserTaskStatus { get; set; }

        public int ProjectID { get; set; }

        public virtual Project Project { get; set; }

        public int? ParentTaskID { get; set; }

        public virtual ParentTask ParentTask { get; set; }

        public int UserID { get; set; }

        public virtual User User { get; set; }
    }
}