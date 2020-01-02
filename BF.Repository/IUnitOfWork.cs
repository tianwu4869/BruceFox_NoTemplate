using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BF.Repository.RepositoryInterface;
using BF.Entity;

namespace BF.Repository
{
    public interface IUnitOfWork
    {
        IGenericRepository<Champion> ChampionRepository { get; }
        IGenericRepository<Skin> SkinRepository { get; }
        IChampionJoinSkinRepository ChampionJoinSkinRepository { get; }
        void Save();
    }
}
