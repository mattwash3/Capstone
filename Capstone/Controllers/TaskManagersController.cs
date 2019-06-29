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
    public class TaskManagersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TaskManagersController(ApplicationDbContext context)
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
        //    List<TaskManager> taskManager = new List<TaskManager>();
        //    var currentUser = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    Manager manager = _context.Manager.Where(m => m.ApplicationUserId == currentUser).FirstOrDefault();
        //    return manager;
        //}

        // GET: TaskManagers
        public async Task<IActionResult> Index()
        {
            return View(await _context.TaskManager.ToListAsync());
        }

        // GET: TaskManagers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskManager = await _context.TaskManager
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskManager == null)
            {
                return NotFound();
            }

            return View(taskManager);
        }

        // GET: TaskManagers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TaskManagers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] TaskLog taskManager)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taskManager);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taskManager);
        }

        // GET: TaskManagers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskManager = await _context.TaskManager.FindAsync(id);
            if (taskManager == null)
            {
                return NotFound();
            }
            return View(taskManager);
        }

        // POST: TaskManagers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] TaskLog taskManager)
        {
            if (id != taskManager.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taskManager);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskManagerExists(taskManager.Id))
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
            return View(taskManager);
        }

        // GET: TaskManagers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskManager = await _context.TaskManager
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskManager == null)
            {
                return NotFound();
            }

            return View(taskManager);
        }

        // POST: TaskManagers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taskManager = await _context.TaskManager.FindAsync(id);
            _context.TaskManager.Remove(taskManager);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskManagerExists(int id)
        {
            return _context.TaskManager.Any(e => e.Id == id);
        }
    }
}
