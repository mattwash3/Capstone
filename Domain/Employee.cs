using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Domain
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        [NotMapped]
        public List<string> DailyTaskLog { get; set; }
        [NotMapped]
        public List<string> WeeklyTaskLog { get; set; }
        [NotMapped]
        public List<string> MonthlyTaskLog { get; set; }
        [ForeignKey("TaskLog")]
        public string TaskLogId { get; set; }
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
