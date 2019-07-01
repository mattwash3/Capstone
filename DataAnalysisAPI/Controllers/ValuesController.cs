using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Capstone;
using Infrastructure;
using Domain;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Microsoft.AspNetCore.Http;

namespace DataAnalysisAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ValuesController : ControllerBase
    {
        private ApplicationDbContext _context;

        public ValuesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            List<TaskLog> taskLogList = _context.TaskLog.ToList();
            return Ok(taskLogList);
        }

        // GET api/values/5
        //[System.Web.Http.HttpGet("{id}")]
        [System.Web.Http.HttpGet()]
        public ActionResult<string> Get(int id)
        {
            TaskLog taskLog = _context.TaskLog.Find(id);
            if (taskLog == null)
            {
                return NotFound();
            }
            return Ok(taskLog);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([System.Web.Http.FromBody] TaskLog taskLog)
        {
            _context.TaskLog.Add(taskLog);
            new TaskLog { };
            _context.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = taskLog.Id }, taskLog);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TaskLog taskLog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != taskLog.Id)
            {
                return BadRequest();
            }
            _context.Entry(taskLog).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskLogExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return StatusCode(StatusCodes.Status204NoContent);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            TaskLog taskLog = _context.TaskLog.Find(id);
            if (taskLog == null)
            {
                return NotFound();
            }

            _context.TaskLog.Remove(taskLog);
            _context.SaveChanges();

            return Ok(taskLog);
        }

        private bool TaskLogExists(int id)
        {
            return _context.TaskLog.Count(t => t.Id == id) > 0;
        }
    }
}
