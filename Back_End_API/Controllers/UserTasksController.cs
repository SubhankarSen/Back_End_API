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
    public class UserTasksController : ApiController
    {
        private Back_End_APIContext db = new Back_End_APIContext();

        // GET: api/UserTasks
        public IQueryable<UserTask> GetUserTasks()
        {
            return db.UserTasks;
        }

        // GET: api/UserTasks/5
        [ResponseType(typeof(UserTask))]
        public async Task<IHttpActionResult> GetUserTask(int id)
        {
            UserTask userTask = await db.UserTasks.FindAsync(id);
            if (userTask == null)
            {
                return NotFound();
            }

            return Ok(userTask);
        }

        // PUT: api/UserTasks/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUserTask(int id, UserTask userTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userTask.UserTaskID)
            {
                return BadRequest();
            }

            db.Entry(userTask).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserTaskExists(id))
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

        // POST: api/UserTasks
        [ResponseType(typeof(UserTask))]
        public async Task<IHttpActionResult> PostUserTask(UserTask userTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserTasks.Add(userTask);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = userTask.UserTaskID }, userTask);
        }

        // DELETE: api/UserTasks/5
        [ResponseType(typeof(UserTask))]
        public async Task<IHttpActionResult> DeleteUserTask(int id)
        {
            UserTask userTask = await db.UserTasks.FindAsync(id);
            if (userTask == null)
            {
                return NotFound();
            }

            db.UserTasks.Remove(userTask);
            await db.SaveChangesAsync();

            return Ok(userTask);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserTaskExists(int id)
        {
            return db.UserTasks.Count(e => e.UserTaskID == id) > 0;
        }
    }
}