using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Manager> Manager { get; set; }
        public DbSet<TaskLog> TaskManager { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
    }
}
