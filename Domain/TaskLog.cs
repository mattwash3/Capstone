using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class TaskLog
    {
        [Key]
        public int Id { get; set; }   
        [Display(Name = "Log Date")]
        [DataType(DataType.Date)]
        public DateTime LogDate { get; set; }
        public IList<TaskEntry> TaskEntries { get; set; }
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        //[ForeignKey("Employee")]
        //public int EmployeeId { get; set; }
        //public Employee Employee { get; set; }
        //[ForeignKey("Manager")]
        //public int? Manager { get; set; }
        //public Manager Manager { get; set; }
        //change to application user

        //public double GetTotalTaskTime()
        //{
        //    TaskLog taskLog = new TaskLog();
        //    double totalTaskTime = 0;
        //    foreach (var taskEntry in taskLog.TaskEntries)
        //    {
        //        totalTaskTime += taskEntry.TaskTime;
        //    }
        //    return totalTaskTime;
        //}
    }
}
