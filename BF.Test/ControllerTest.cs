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
        [TestMethod]
        public void PostChampionTest()
        {
            var controller = new LeagueController(new UnitOfWork(new BruceFoxContext()));
            var champion = new Champion();
            champion.Name = "Illaoi";
            champion.Difficulty = 1;
            champion.Class = "Fighter";
            System.Diagnostics.Debug.WriteLine(champion.Name);
            var result = controller.PostChamion(champion) as OkNegotiatedContentResult<Champion>;
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content.Name, champion.Name);
        }

        [TestMethod]
        public void PutChampionTest()
        {
            var controller = new LeagueController(new UnitOfWork(new BruceFoxContext()));
            var champion = new Champion();
            champion.ID = 2;
            champion.Name = "Morgana";
            champion.Difficulty = 2;
            champion.Class = "Tank";
            System.Diagnostics.Debug.WriteLine(champion.Name);
            var result = controller.PutChampion(champion) as StatusCodeResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(result.StatusCode, HttpStatusCode.NoContent);
        }
    }
}
