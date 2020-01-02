using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BF.Repository.RepositoryInterface;
using BF.Entity;
using System.Data.Entity;

namespace BF.Repository
{
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
    {
        private BruceFoxContext Context;
        private DbSet<Entity> DbSet;

        public GenericRepository(BruceFoxContext bruceFoxContext)
        {
            Context = bruceFoxContext;
            DbSet = Context.Set<Entity>();
        }

        public Entity GetById(int id)
        {
            return DbSet.Find(id);
        }

        public List<Entity> GetAll()
        {
            return DbSet.ToList();
        }

        public void Insert(Entity entity)
        {
            DbSet.Add(entity);
        }

        public void Delete(int id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public void Update(Entity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }
    }
}
