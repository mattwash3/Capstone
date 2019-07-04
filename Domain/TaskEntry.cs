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
        public string TaskType { get; set; }
        public string Comment { get; set; }
        public int TaskTime { get; set; }
        [ForeignKey("TaskLog")]
        public int TaskLogId { get; set; }
        public TaskLog TaskLog { get; set; }
    }
}
