using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BF.Repository.RepositoryInterface;
using BF.Repository;
using BF.Entity;
using System.Data.Entity.Infrastructure;
using BF.Web.Filters;

namespace BF.Web.Controllers
{
    [ControllerLevelExceptionFilter]
    public class LeagueController : ApiController
    {
        private IUnitOfWork unitOfWork;

        public LeagueController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        [Route("api/PostChampion")]
        public IHttpActionResult PostChamion(Champion champion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            unitOfWork.ChampionRepository.Insert(champion);
            unitOfWork.Save();

            return Ok(champion);
        }

        [Route("api/PutChampion")]
        public IHttpActionResult PutChampion(Champion champion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            unitOfWork.ChampionRepository.Update(champion);
            unitOfWork.Save();

            return StatusCode(HttpStatusCode.NoContent);
        }

        [Route("api/PostSkin")]
        [ActionLevelExceptionFilter]
        public IHttpActionResult PostSkin(Skin skin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            unitOfWork.SkinRepository.Insert(skin);
            unitOfWork.Save();

            return Ok();
        }

        [Route("api/ChampionJoinSkin")]
        public IHttpActionResult GetChampionJoinSkin()
        {
            var list = unitOfWork.ChampionJoinSkinRepository.GetAll();
            return Ok(list);
        }
    }
}
