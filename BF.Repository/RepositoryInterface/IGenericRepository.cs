using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BF.Repository.RepositoryInterface
{
    public interface IGenericRepository<Entity>
    {
        Entity GetById(int id);

        List<Entity> GetAll();

        void Insert(Entity entity);

        void Delete(int id);

        void Update(Entity entity);
    }
}
