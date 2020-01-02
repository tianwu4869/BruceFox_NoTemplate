using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BF.Entity;

namespace BF.Repository.RepositoryInterface
{
    public interface IChampionJoinSkinRepository
    {
        List<ChampionJoinSkin> GetAll();
    }
}
