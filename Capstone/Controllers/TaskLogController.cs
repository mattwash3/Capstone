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

        // GET: TaskLogs
        public async Task<IActionResult> Index()
        {
            //var user = (System.Security.Claims.ClaimsIdentity)User.Identity;
            //var userId = user.FindFirstValue("UserId");
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
                .Include(t => t.TaskEntries)
                .Include(e => e.ApplicationUser)
                .Single(t => t.Id == id);
            ViewBag.title = "Entries in Task Log:" + taskLog.Id;

            if (taskLog == null)
            {
                return NotFound();
            }

            return View(taskLog);
        }

        // GET: TaskLogs/Create
        public IActionResult Create()
        {
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "Id");
            return View();
        }

        // POST: TaskLogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TaskEntries,LogDate,ApplicationUserId")] TaskLog taskLog)
        {
            if (ModelState.IsValid)
            {
                if (User.IsInRole("Employee"))
                {
                    var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    var applicationUser = _context.Employee.Where(c => c.ApplicationUserId == userId).FirstOrDefault();
                    taskLog.ApplicationUserId = userId;
                    _context.Add(taskLog);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                if (User.IsInRole("Manager"))
                {
                    var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    var applicationUser = _context.Manager.Where(c => c.ApplicationUserId == userId).FirstOrDefault();
                    taskLog.ApplicationUserId = userId;
                    _context.Add(taskLog);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "Id");
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,TaskEntries,LogDate,ApplicationUserId")] TaskLog taskLog)
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

        private double GetTotalTaskTime(int id)
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
