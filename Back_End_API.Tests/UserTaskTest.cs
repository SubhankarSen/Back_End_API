using Back_End_API.Controllers;
using Back_End_API.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace Back_End_API.Tests
{
    [TestFixture]
    public class UserTaskTest
    {
        [Test]
        public async Task CheckUserTaskExist()
        {
            var obj = new UserTasksController();
            var res = await obj.GetUserTask(2) as OkNegotiatedContentResult<UserTask>;
            Assert.IsNotNull(res);
            Assert.AreEqual(res.Content.UserTaskID, 2);
        }

        [Test]
        public async Task CheckUserTaskNotExist()
        {
            var obj = new UserTasksController();
            var res = await obj.GetUserTask(500) as OkNegotiatedContentResult<UserTask>;
            Assert.IsNull(res);
            //Assert.AreEqual(res.Content.UserTaskID, null);
        }

        [Test]
        public void TestGetAllUserTasks()
        {
            //var demoUserTasks = GetDemoUserTasks();
            var obj = new UserTasksController();
            var UserTaskList = new List<UserTask>();
            //var UserTaskList = obj.GetUserTasks() as List<UserTask>;
            UserTaskList = obj.GetUserTasks() as List<UserTask>;

            // While Unit Testing the count of User tasks in the Database was 21
            Assert.AreEqual(20, UserTaskList.Count);
        }

        [Test]
        public async Task TestPostUserTask()
        {
            var obj = new UserTasksController();
            var demoUserTask = GetDemoUserTask();
            var res = await obj.PostUserTask(demoUserTask) as CreatedAtRouteNegotiatedContentResult<UserTask>;
            Assert.IsNotNull(res);
            Assert.AreEqual(res.RouteValues["Id"], res.Content.UserTaskID);
            Assert.AreEqual(res.Content.UserTaskDesc, demoUserTask.UserTaskDesc);
        }

        [Test]
        public async Task TestUpdateUserTask()
        {
            var obj = new UserTasksController();
            var demoUserTask = GetDemoUserTasktoUpdate();
            var res = await obj.PutUserTask(demoUserTask.UserTaskID, demoUserTask) as StatusCodeResult;
            Assert.IsNotNull(res);
            //Assert.IsInstanceOf(res.GetType(), typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, res.StatusCode);
        }

        [Test]
        public async Task TestDeleteUserTask()
        {
            var obj = new UserTasksController();
            //var demoUserTask = GetDemoUserTasktoDelete();
            var res = await obj.DeleteUserTask(2029) as OkNegotiatedContentResult<UserTask>;
            Assert.IsNotNull(res);
            Assert.AreEqual(2029, res.Content.UserTaskID);
        }

        UserTask GetDemoUserTask()
        {
            return new UserTask()
            {
                UserTaskID = 99,
                ProjectID = 1,
                ParentTaskID = 1,
                UserID = 1,
                UserTaskDesc = "Demo User Task",
                UserTaskStartDate = Convert.ToDateTime("2019-08-02"),
                UserTaskEndDate = Convert.ToDateTime("2019-08-03"),
                UserTaskPriority = 30,
                UserTaskStatus = true
            };
        }

        UserTask GetDemoUserTasktoUpdate()
        {
            return new UserTask()
            {
                UserTaskID = 2024,
                ProjectID = 1,
                ParentTaskID = 1,
                UserID = 1,
                UserTaskDesc = "Demo User Task Updated",
                UserTaskStartDate = Convert.ToDateTime("2019-08-02"),
                UserTaskEndDate = Convert.ToDateTime("2019-08-03"),
                UserTaskPriority = 30,
                UserTaskStatus = true
            };
        }
    }
}
