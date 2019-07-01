﻿using System;
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



        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        [ForeignKey("Manager")]
        public int ManagerId { get; set; }
        public Manager Manager { get; set; }
        [ForeignKey("TaskEntry")]
        public TaskEntry TaskEntry { get; set; }
    }
}
