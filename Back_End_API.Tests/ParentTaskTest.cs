using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Back_End_API.Controllers;
using System.Web.Http.Results;
using Back_End_API.Models;
using System.Net;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Back_End_API.Tests
{
    [TestFixture]
    public class ParentTaskTest
    {
        [Test]
        public async Task CheckParentTaskExist()
        {
            var obj = new ParentTasksController();
            var res = await obj.GetParentTask(2) as OkNegotiatedContentResult<ParentTask>;
            Assert.IsNotNull(res);
            Assert.AreEqual(res.Content.ParentTaskID, 2);
        }

        [Test]
        public async Task CheckParentTaskNotExist()
        {
            var obj = new ParentTasksController();
            var res = await obj.GetParentTask(10) as OkNegotiatedContentResult<ParentTask>;
            Assert.IsNull(res);
            //Assert.AreEqual(res.Content.ParentTaskID, null);
        }

        [Test]
        public void TestGetAllParentTasks()
        {
            //var demoParentTasks = GetDemoParentTasks();
            var obj = new ParentTasksController();
            var ParentTaskList = new List<ParentTask>();
            //var ParentTaskList = obj.GetParentTasks() as List<ParentTask>;
            ParentTaskList = obj.GetParentTasks() as List<ParentTask>;

            // While Unit Testing the count of Parent tasks in the Database was 15
            Assert.AreEqual(15,ParentTaskList.Count);
        }

        [Test]
        public async Task TestPostParentTask()
        {
            var obj = new ParentTasksController();
            var demoParentTask = GetDemoParentTask();
            var res = await obj.PostParentTask(demoParentTask) as CreatedAtRouteNegotiatedContentResult<ParentTask>;
            Assert.IsNotNull(res);
            Assert.AreEqual(res.RouteValues["Id"], res.Content.ParentTaskID);
            Assert.AreEqual(res.Content.ParentTaskDesc, demoParentTask.ParentTaskDesc);
        }

        [Test]
        public async Task TestUpdateParentTask()
        {
            var obj = new ParentTasksController();
            var demoParentTask = GetDemoParentTasktoUpdate();
            var res = await obj.PutParentTask(demoParentTask.ParentTaskID, demoParentTask) as StatusCodeResult;
            Assert.IsNotNull(res);
            //Assert.IsInstanceOf(res.GetType(), typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, res.StatusCode);
        }

        [Test]
        public async Task TestDeleteParentTask()
        {
            var obj = new ParentTasksController();
            //var demoParentTask = GetDemoParentTasktoDelete();
            var res = await obj.DeleteParentTask(2016) as OkNegotiatedContentResult<ParentTask>;
            Assert.IsNotNull(res);
            Assert.AreEqual(2016, res.Content.ParentTaskID);
        }

        ParentTask GetDemoParentTask()
        {
            return new ParentTask()
            {
                ParentTaskID = 99,
                ParentTaskDesc = "Demo Parent Task"
            };
        }

        ParentTask GetDemoParentTasktoUpdate()
        {
            return new ParentTask()
            {
                ParentTaskID = 2014,
                ParentTaskDesc = "Demo Parent Task Update"
            };
        }


        //private List<ParentTask> GetDemoParentTasks()
        //{
        //    var demoParentTasks = new List<ParentTask>();
        //    demoParentTasks.Add(new ParentTask { ParentTaskID = 97, ParentTaskDesc = "Demo Parent Task 97" });
        //    demoParentTasks.Add(new ParentTask { ParentTaskID = 98, ParentTaskDesc = "Demo Parent Task 98" });
        //    demoParentTasks.Add(new ParentTask { ParentTaskID = 99, ParentTaskDesc = "Demo Parent Task 99" });
        //    return demoParentTasks;
        //}
    }
}