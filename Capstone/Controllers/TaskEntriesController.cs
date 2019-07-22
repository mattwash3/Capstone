using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain;
using System.Security.Claims;

namespace Capstone.Controllers
{
    public class TaskEntriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TaskEntriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TaskEntries
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TaskEntry.Include(t => t.TaskLog);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TaskEntries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskEntry = await _context.TaskEntry
                .Include(t => t.TaskLog)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskEntry == null)
            {
                return NotFound();
            }

            return View(taskEntry);
        }

        // GET: TaskEntries/Create/5
        public IActionResult Create(int id)
        {

            ViewData["TaskLogId"] = new SelectList(_context.TaskLog, "Id", "Id");
            return View();
        }

        // POST: TaskEntries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id, [Bind("Id,TaskType,Comment,TaskTime,TaskLogId")] TaskEntry taskEntry)
        {
            if (ModelState.IsValid)
            {
                if (User.IsInRole("Employee"))
                {
                    var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    var employee = _context.Employee.Where(c => c.ApplicationUserId == userId).FirstOrDefault();
                    var taskLog = _context.TaskLog.Where(t => t.ApplicationUserId == userId).LastOrDefault();
                    taskEntry.TaskLogId = taskLog.Id;
                    _context.Add(taskEntry);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                if (User.IsInRole("Manager"))
                {
                    var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    var manager = _context.Manager.Where(c => c.ApplicationUserId == userId).FirstOrDefault();
                    var taskLog = _context.TaskLog.Where(t => t.ApplicationUserId == userId).LastOrDefault();
                    taskEntry.TaskLogId = taskLog.Id;
                    _context.Add(taskEntry);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["TaskLogId"] = new SelectList(_context.TaskLog, "Id", "Id");
            return View(taskEntry);
        }

        // GET: TaskEntries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskEntry = await _context.TaskEntry.FindAsync(id);
            if (taskEntry == null)
            {
                return NotFound();
            }
            ViewData["TaskLogId"] = new SelectList(_context.TaskLog, "Id", "Id", taskEntry.TaskLogId);
            return View(taskEntry);
        }

        // POST: TaskEntries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TaskType,Comment,TaskTime,TaskLogId")] TaskEntry taskEntry)
        {
            if (id != taskEntry.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taskEntry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskEntryExists(taskEntry.Id))
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
            ViewData["TaskLogId"] = new SelectList(_context.TaskLog, "Id", "Id", taskEntry.TaskLogId);
            return View(taskEntry);
        }

        // GET: TaskEntries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskEntry = await _context.TaskEntry
                .Include(t => t.TaskLog)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskEntry == null)
            {
                return NotFound();
            }

            return View(taskEntry);
        }

        // POST: TaskEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taskEntry = await _context.TaskEntry.FindAsync(id);
            _context.TaskEntry.Remove(taskEntry);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskEntryExists(int id)
        {
            return _context.TaskEntry.Any(e => e.Id == id);
        }

        public IActionResult CreateTaskEntry()
        {
            return View();
        }

        [HttpPost, ActionName("CreateTaskEntry")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTaskEntry([Bind("Id,TaskType,Comment,TaskTime,TaskLogId")] TaskEntry taskEntry)
        {
            if (ModelState.IsValid)
            {
                if (User.IsInRole("Employee"))
                {
                    var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    var applicationUser = _context.Employee.Where(c => c.ApplicationUserId == userId).FirstOrDefault();
                    _context.Add(taskEntry);
                    _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                if (User.IsInRole("Manager"))
                {
                    var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    var applicationUser = _context.Manager.Where(c => c.ApplicationUserId == userId).FirstOrDefault();
                    _context.Add(taskEntry);
                    _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(taskEntry);
        }

        public ActionResult SubmitTaskEntry([Bind("Id,TaskType,Comment,TaskTime,TaskLogId")] TaskEntry taskEntry)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Employee employee = _context.Employee.Where(c => c.ApplicationUserId == userId).FirstOrDefault();
            taskEntry.Id = employee.Id;
            _context.TaskEntry.Add(taskEntry);
            _context.SaveChanges();
            TaskLog taskLog = new TaskLog();
            //taskLog.Entry = taskEntry.TaskType;
            return RedirectToAction("CreateTaskEntry");
        }
    }
}
