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
    public class UserTest
    {
        [Test]
        public async Task CheckUserExist()
        {
            var obj = new UsersController();
            var res = await obj.GetUser(2) as OkNegotiatedContentResult<User>;
            Assert.IsNotNull(res);
            Assert.AreEqual(res.Content.UserID, 2);
        }

        [Test]
        public async Task CheckUserNotExist()
        {
            var obj = new UsersController();
            var res = await obj.GetUser(10) as OkNegotiatedContentResult<User>;
            Assert.IsNull(res);
            //Assert.AreEqual(res.Content.UserID, null);
        }

        [Test]
        public void TestGetAllUsers()
        {
            //var demoUsers = GetDemoUsers();
            var obj = new UsersController();
            var UserList = new List<User>();
            //var UserList = obj.GetUsers() as List<User>;
            UserList = obj.GetUsers() as List<User>;

            // While Unit Testing the count of Users in the Database was 6
            Assert.AreEqual(6, UserList.Count);
        }

        [Test]
        public async Task TestPostUser()
        {
            var obj = new UsersController();
            var demoUser = GetDemoUser();
            var res = await obj.PostUser(demoUser) as CreatedAtRouteNegotiatedContentResult<User>;
            Assert.IsNotNull(res);
            Assert.AreEqual(res.RouteValues["Id"], res.Content.UserID);
            Assert.AreEqual(res.Content.UserFirstName, demoUser.UserFirstName);
        }

        [Test]
        public async Task TestUpdateUser()
        {
            var obj = new UsersController();
            var demoUser = GetDemoUsertoUpdate();
            var res = await obj.PutUser(demoUser.UserID, demoUser) as StatusCodeResult;
            Assert.IsNotNull(res);
            //Assert.IsInstanceOf(res.GetType(), typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, res.StatusCode);
        }

        [Test]
        public async Task TestDeleteUser()
        {
            var obj = new UsersController();
            //var demoUser = GetDemoUsertoDelete();
            var res = await obj.DeleteUser(26) as OkNegotiatedContentResult<User>;
            Assert.IsNotNull(res);
            Assert.AreEqual(26, res.Content.UserID);
        }

        User GetDemoUser()
        {
            return new User()
            {
                UserID = 99,
                UserFirstName = "Demo User FN",
                UserLastName = "Demo User LN",
                UserEmployeeID = 30
            };
        }

        User GetDemoUsertoUpdate()
        {
            return new User()
            {
                UserID = 22,
                UserFirstName = "Demo User FN Updated",
                UserLastName = "Demo User LN Updated",
                UserEmployeeID = 30
            };
        }
    }
}
