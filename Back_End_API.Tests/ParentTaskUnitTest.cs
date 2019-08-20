using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Back_End_API.Models;
using Back_End_API.Controllers;
using NUnit.Framework;
using System.Web.Http.Results;

namespace Back_End_API.Tests
{
    [TestFixture]
    public class ParentTaskUnitTest
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
        }

        [Test]
        public void TestGetAllParentTasks()
        {
            ParentTasksController obj = new ParentTasksController();
            var res = obj.GetParentTasks() as List<ParentTask>;
            List<ParentTask> ParentTaskList = new List<ParentTask>();
            ParentTaskList = obj.GetParentTasks() as List<ParentTask>;
            //Assert.IsNotNull(res);
            Assert.AreEqual(5, ParentTaskList.Count);
        }

        [Test]
        public async Task TestPostParentTask()
        {
            var obj = new ParentTasksController();
            var demoParentTask = GetDemoParentTask();
            var res = await obj.PostParentTask(demoParentTask) as CreatedAtRouteNegotiatedContentResult<ParentTask>;
            Assert.IsNotNull(res);
            Assert.AreEqual(res.RouteValues["ParentTaskID"], res.Content.ParentTaskID);
            Assert.AreEqual(res.Content.ParentTaskDesc, demoParentTask.ParentTaskDesc);
        }

        [Test]
        public async Task TestUpdateParentTask()
        {
            var obj = new ParentTasksController();
            var demoParentTask = GetDemoParentTask();
            var res = await obj.PutParentTask(demoParentTask.ParentTaskID, demoParentTask) as StatusCodeResult;
            Assert.IsNotNull(res);
            Assert.IsNotInstanceOf(res.GetType(), typeof(StatusCodeResult));
        }

        [Test]
        public async Task TestDeleteParentTask()
        {
            var obj = new ParentTasksController();
            var demoParentTask = GetDemoParentTask();
            var res = await obj.DeleteParentTask(demoParentTask.ParentTaskID) as OkNegotiatedContentResult<ParentTask>;
            Assert.IsNotNull(res);
            Assert.AreEqual(demoParentTask.ParentTaskID, res.Content.ParentTaskID);
        }

        ParentTask GetDemoParentTask()
        {
            return new ParentTask()
            {
                ParentTaskID = 99,
                ParentTaskDesc = "Demo Parent Task"
            };
        }
    }
}
