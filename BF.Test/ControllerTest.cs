using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BF.Web.Controllers;
using BF.Repository;
using BF.Entity;
using System.Web.Http.Results;
using System.Net;

namespace BF.Test
{
    [TestClass]
    public class ControllerTest
    {
        private static LeagueController controller;

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            controller = new LeagueController(new UnitOfWork(new BruceFoxContext()));
        }

        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //    unitOfWork = new UnitOfWork(new BruceFoxContext());
        //}

        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void GetChampionTest()
        {
            var result = controller.GetChampion(1) as OkNegotiatedContentResult<Champion>;
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content.Name, "Ilaoi");
        }

        [TestMethod]
        public void PostChampionTest()
        {
            var champion = new Champion();
            champion.Name = "Akali";
            champion.Difficulty = 3;
            champion.Class = "Slayer";
            var result = controller.PostChampion(champion) as OkNegotiatedContentResult<Champion>;
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content.Name, champion.Name);
        }

        [TestMethod]
        public void PutChampionTest()
        {
            var champion = new Champion();
            champion.ID = 2;
            champion.Name = "Morgana";
            champion.Difficulty = 2;
            champion.Class = "Tank";
            var result = controller.PutChampion(champion) as StatusCodeResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(result.StatusCode, HttpStatusCode.NoContent);
        }
    }
}
