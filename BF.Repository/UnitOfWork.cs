using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BF.Entity;
using BF.Repository.RepositoryInterface;

namespace BF.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private BruceFoxContext Context;
        private IGenericRepository<Champion> _ChampionRepository;
        private IGenericRepository<Skin> _SkinRepository;
        private IChampionJoinSkinRepository _ChampionJoinSkinRepository;

        public UnitOfWork(BruceFoxContext context)
        {
            Context = context;
        }

        public IGenericRepository<Champion> ChampionRepository
        {
            get { return _ChampionRepository ?? (_ChampionRepository = new GenericRepository<Champion>(Context)); }
        }

        public IGenericRepository<Skin> SkinRepository
        {
            get { return _SkinRepository ?? (_SkinRepository = new GenericRepository<Skin>(Context)); }
        }

        public IChampionJoinSkinRepository ChampionJoinSkinRepository
        {
            get { return _ChampionJoinSkinRepository ?? (_ChampionJoinSkinRepository = new ChampionJoinSkinRepository(Context)); }
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
