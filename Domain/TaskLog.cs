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
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public double GetTotalTaskTime()
        {
            TaskLog taskLog = new TaskLog();
            double totalTaskTime = 0;
            foreach (var taskEntry in taskLog.TaskEntries)
            {
                totalTaskTime += taskEntry.TaskTime;
            }
            return totalTaskTime;
        }
    }
}

//put new method into the class so you skip the input to the entries
// .gettotaltasttime() in cshtml

//model as input to the method if kept in cotroller 