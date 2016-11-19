using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SoftCloudTraining.Controllers;
using SoftCloudTraining.Models;
using SoftCloudTraining.DAL;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using System.Net;

namespace SoftCloudTraining.Tests.Controllers
{

    [TestClass]
    public class CandidateControllerTest
    {
        /// <summary>
        ///Initialize() is called once during test execution before
        ///test methods in this test class are executed.
        ///</summary>
        [TestInitialize()]
        public void Initialize()
        {
            //  TODO: Add test initialization code
        }

        /// <summary>
        ///Cleanup() is called once during test execution after
        ///test methods in this class have executed unless
        ///this test class' Initialize() method throws an exception.
        ///</summary>
        [TestCleanup()]
        public void Cleanup()
        {

            //  TODO: Add test cleanup code
        }

        private string sPortConfig = ":49906";

        private CandidateController SetUpController()
        {
            // Arrange
            CandidateController controller = new CandidateController(new CandidateDbCtx());

            // Setup Request
            controller.Request = new HttpRequestMessage
            {
                RequestUri = new Uri(String.Format("http://localhost{0}/candidate", sPortConfig))
            };
            controller.Configuration = new HttpConfiguration();
            controller.Configuration.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            controller.RequestContext.RouteData = new HttpRouteData(
                route: new HttpRoute(),
                values: new HttpRouteValueDictionary { { "controller", "candidate" } });

            return controller;
        }


        [TestMethod]
        public void Get()
        {
            // Arrange
            CandidateController controller = SetUpController();

            // Act
            IEnumerable<Candidate> result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count(), 9);
            // assuming no sorting
            Assert.AreEqual(result.ElementAt(0).name, "Guy 1");
            
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            CandidateController controller = SetUpController();

            // Act
            Candidate result = controller.Get(5);

            // Assert
            Assert.AreEqual(result.name, "Guy 5");

        }
        
        [TestMethod]
        public void Post()
        {
            // Arrange
            CandidateController controller = SetUpController();

            // count before
            IEnumerable<Candidate> list1 = controller.Get();
            int countBefore = list1.Count();

            // Act
            Candidate candidate = new Candidate() { name = "Some Guy", developer=true, qa=true };
            var response = controller.Post(candidate);

            // Assert Location
            // For this mock DB, 10 will be the next generated 01
            Assert.AreEqual(String.Format("http://localhost{0}/softclouds/candidate/10", sPortConfig), response.Headers.Location.AbsoluteUri);

            // Response status s/b 201 created
            Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);

            /// It might be wiser to have a return count method and test that
            list1 = controller.Get();
            int countAfter = list1.Count();

            Assert.AreEqual(countAfter, countBefore + 1);

        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            CandidateController controller = SetUpController();
            
            // count before
            IEnumerable<Candidate> list1 = controller.Get();
            int countBefore = list1.Count();
            var response = controller.Delete(5);

            /// It might be wiser to have a return count method and test that
            list1 = controller.Get();
            int countAfter = list1.Count();

            Assert.AreEqual(countAfter, countBefore - 1);

            // Response status s/b 200 OK
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);

        }

        [TestMethod]
        public void DeleteNonExisting()
        {
            // Arrange
            CandidateController controller = SetUpController();

            // 888 does not exist
            var response = controller.Delete(888);
            
            // Response status Not Found
            Assert.AreEqual(response.StatusCode, HttpStatusCode.NotFound);

        }

        [TestMethod]
        public void Put()
        {
            // Arrange
            CandidateController controller = SetUpController();
            Candidate candidateBefore = controller.Get(7);

            // Act
            candidateBefore.name = "Some Guy";
            var response = controller.Put(7, candidateBefore);


            Candidate candidateAfter = controller.Get(7);

            // Response status s/b 200 OK
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);

            // Name was changed
            Assert.AreEqual(candidateAfter.name, "Some Guy");
            
            // No change
            Assert.AreEqual(candidateAfter.phone, candidateBefore.phone);

        }



    }
}
