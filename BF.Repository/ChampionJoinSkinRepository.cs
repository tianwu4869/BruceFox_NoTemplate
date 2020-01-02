using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BF.Repository.RepositoryInterface;
using BF.Entity;

namespace BF.Repository
{
    public class ChampionJoinSkinRepository : IChampionJoinSkinRepository
    {
        private BruceFoxContext Context;

        public ChampionJoinSkinRepository(BruceFoxContext bruceFoxContext)
        {
            Context = bruceFoxContext;
        }

        public List<ChampionJoinSkin> GetAll()
        {
            return Context.ChampionSet.Join(Context.SkinSet,
                o => o.ID,
                i => i.Champion_ID,
                (o, i) => new ChampionJoinSkin
                {
                    ChampionName = o.Name,
                    SkinName = i.Skin_Name
                }).ToList();
        }
    }
}
