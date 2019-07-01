using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class TaskEntry
    {
        [Key]
        public int Id { get; set; }
        public string Call { get; set; }
        public string Email { get; set; }
        public string Meeting { get; set; }
        public string Other { get; set; }
        [ForeignKey("TaskLog")]
        public int TaskLogId { get; set; }
        public TaskLog TaskLog { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        [ForeignKey("Manager")]
        public int ManagerId { get; set; }
        public Manager Manager { get; set; }
    }
}
