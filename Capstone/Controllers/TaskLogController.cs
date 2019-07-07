using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Capstone.Models;
using System.Security.Claims;
using Domain;
using ApplicationDbContext = Domain.ApplicationDbContext;

namespace Capstone.Controllers
{
    public class TaskLogController : Controller
    {
        private ApplicationDbContext _context;

        public TaskLogController(ApplicationDbContext context)
        {
            _context = context;
        }

        //public ApplicationUser GetLoggedInUser()
        //{
        //    var currentUser = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    Employee employee = _context.Employee.Where(e => e.ApplicationUserId == currentUser).FirstOrDefault();
        //    Manager manager = _context.Manager.Where(m => m.ApplicationUserId == currentUser).FirstOrDefault();
        //    return currentUser;
        //}

        //public Manager GetLoggedInUser()
        //{
        //    List<TaskLog> taskLog = new List<TaskLog>();
        //    var currentUser = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    Manager manager = _context.Manager.Where(m => m.ApplicationUserId == currentUser).FirstOrDefault();
        //    return manager;
        //}

        // GET: TaskLogs
        public async Task<IActionResult> Index()
        {
            IList<TaskEntry> taskEntries = _context.TaskEntry.Include(t => t.TaskLog).ToList();
            return View(await _context.TaskLog.ToListAsync());
        }

        // GET: TaskLogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TaskLog taskLog = _context.TaskLog
            //var taskLog = await _context.TaskLog
                .Include(t => t.TaskEntries)
                .Include(e => e.Employee)
                .Single(t => t.Id == id);
            //.FirstOrDefaultAsync(m => m.Id == id);
            ViewBag.title = "Entries in Task Log:" + taskLog.Id;

            if (taskLog == null)
            {
                return NotFound();
            }

            return View(taskLog);
            //return View("Index", taskLog.TaskEntries);
        }

        // GET: TaskLogs/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "Id");
            return View();
        }

        // POST: TaskLogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TaskEntries,LogDate,EmployeeId")] TaskLog taskLog)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var employee = _context.Employee.Where(c => c.ApplicationUserId == userId).FirstOrDefault();
                taskLog.EmployeeId = employee.Id;
                _context.Add(taskLog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "Id");
            return View(taskLog);
        }

        // GET: TaskLogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskLog = await _context.TaskLog.FindAsync(id);
            if (taskLog == null)
            {
                return NotFound();
            }
            return View(taskLog);
        }

        // POST: TaskLogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TaskEntries,LogDate,EmployeeId")] TaskLog taskLog)
        {
            if (id != taskLog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taskLog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskManagerExists(taskLog.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(taskLog);
        }

        // GET: TaskLogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskLog = await _context.TaskLog
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskLog == null)
            {
                return NotFound();
            }

            return View(taskLog);
        }

        // POST: TaskLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taskLog = await _context.TaskLog.FindAsync(id);
            _context.TaskLog.Remove(taskLog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskManagerExists(int id)
        {
            return _context.TaskLog.Any(e => e.Id == id);
        }

        private double GetTotalTaskTime()
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
