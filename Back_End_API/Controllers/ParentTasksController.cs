using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Back_End_API.Models;

namespace Back_End_API.Controllers
{
    public class ParentTasksController : ApiController
    {
        private Back_End_APIContext db = new Back_End_APIContext();

        // GET: api/ParentTasks
        public List<ParentTask> GetParentTasks()
        {
            return db.ParentTasks.ToList();
        }

        // GET: api/ParentTasks/5
        [ResponseType(typeof(ParentTask))]
        public async Task<IHttpActionResult> GetParentTask(int id)
        {
            ParentTask parentTask = await db.ParentTasks.FindAsync(id);
            if (parentTask == null)
            {
                return NotFound();
            }

            return Ok(parentTask);
        }

        // PUT: api/ParentTasks/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutParentTask(int id, ParentTask parentTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != parentTask.ParentTaskID)
            {
                return BadRequest();
            }

            db.Entry(parentTask).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParentTaskExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ParentTasks
        [ResponseType(typeof(ParentTask))]
        public async Task<IHttpActionResult> PostParentTask(ParentTask parentTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ParentTasks.Add(parentTask);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = parentTask.ParentTaskID }, parentTask);
        }

        // DELETE: api/ParentTasks/5
        [ResponseType(typeof(ParentTask))]
        public async Task<IHttpActionResult> DeleteParentTask(int id)
        {
            ParentTask parentTask = await db.ParentTasks.FindAsync(id);
            if (parentTask == null)
            {
                return NotFound();
            }

            db.ParentTasks.Remove(parentTask);
            await db.SaveChangesAsync();

            return Ok(parentTask);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ParentTaskExists(int id)
        {
            return db.ParentTasks.Count(e => e.ParentTaskID == id) > 0;
        }
    }
}