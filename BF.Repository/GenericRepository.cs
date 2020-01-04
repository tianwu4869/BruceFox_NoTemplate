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

        public GenericRepository(BruceFoxContext bruceFoxContext)
        {
            Context = bruceFoxContext;
        }

        public Entity GetById(int id)
        {
            return Context.Set<Entity>().Find(id);
        }

        public List<Entity> GetAll()
        {
            return Context.Set<Entity>().ToList();
        }

        public void Insert(Entity entity)
        {
            Context.Set<Entity>().Add(entity);
        }

        public void Delete(int id)
        {
            Context.Set<Entity>().Remove(Context.Set<Entity>().Find(id));
        }

        public void Update(Entity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }
    }
}
