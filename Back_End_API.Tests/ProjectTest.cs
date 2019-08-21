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
    public class ProjectTest
    {
        [Test]
        public async Task CheckProjectExist()
        {
            var obj = new ProjectsController();
            var res = await obj.GetProject(2) as OkNegotiatedContentResult<Project>;
            Assert.IsNotNull(res);
            Assert.AreEqual(res.Content.ProjectID, 2);
        }

        [Test]
        public async Task CheckProjectNotExist()
        {
            var obj = new ProjectsController();
            var res = await obj.GetProject(10) as OkNegotiatedContentResult<Project>;
            Assert.IsNull(res);
            //Assert.AreEqual(res.Content.ProjectID, null);
        }

        [Test]
        public void TestGetAllProjects()
        {
            //var demoProjects = GetDemoProjects();
            var obj = new ProjectsController();
            var ProjectList = new List<Project>();
            //var ProjectList = obj.GetProjects() as List<Project>;
            ProjectList = obj.GetProjects() as List<Project>;

            // While Unit Testing the count of Projects in the Database was 6
            Assert.AreEqual(6, ProjectList.Count);
        }

        [Test]
        public async Task TestPostProject()
        {
            var obj = new ProjectsController();
            var demoProject = GetDemoProject();
            var res = await obj.PostProject(demoProject) as CreatedAtRouteNegotiatedContentResult<Project>;
            Assert.IsNotNull(res);
            Assert.AreEqual(res.RouteValues["Id"], res.Content.ProjectID);
            Assert.AreEqual(res.Content.ProjectDesc, demoProject.ProjectDesc);
        }

        [Test]
        public async Task TestUpdateProject()
        {
            var obj = new ProjectsController();
            var demoProject = GetDemoProjecttoUpdate();
            var res = await obj.PutProject(demoProject.ProjectID, demoProject) as StatusCodeResult;
            Assert.IsNotNull(res);
            //Assert.IsInstanceOf(res.GetType(), typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, res.StatusCode);
        }

        [Test]
        public async Task TestDeleteProject()
        {
            var obj = new ProjectsController();
            //var demoProject = GetDemoProjecttoDelete();
            var res = await obj.DeleteProject(13) as OkNegotiatedContentResult<Project>;
            Assert.IsNotNull(res);
            Assert.AreEqual(13, res.Content.ProjectID);
        }

        Project GetDemoProject()
        {
            return new Project()
            {
                ProjectID = 99,
                UserID = 1,
                ProjectDesc = "Demo Project",
                ProjStartDate = Convert.ToDateTime("2019-08-02"),
                ProjEndDate = Convert.ToDateTime("2019-08-03"),
                ProjPriority = 30
            };
        }

        Project GetDemoProjecttoUpdate()
        {
            return new Project()
            {
                ProjectID = 12,
                UserID = 1,
                ProjectDesc = "Demo Project Updated",
                ProjStartDate = Convert.ToDateTime("2019-08-02"),
                ProjEndDate = Convert.ToDateTime("2019-08-03"),
                ProjPriority = 30
            };
        }
    }
}
