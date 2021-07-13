using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace iTechArt.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext DbContext;
        protected readonly ILogger Logger;


        public Repository(DbContext context, ILogger logger)
        {
            DbContext = context;
            Logger = logger;
        }


        public void Create(T item)
        {
            Logger.LogInformation("Creating a new object with repository");
            DbContext.Set<T>().Add(item);
        }

        public IEnumerable<T> GetAll()
        {
            Logger.LogInformation("Getting all instances of the entity");

            return DbContext.Set<T>().ToList();
        }

        public T GetOne(int id)
        {
            Logger.LogInformation($"Trying to find an object with id {id} in the db");

            return DbContext.Set<T>().Find(id);
        }

        public void Delete(int id)
        {
            Logger.LogInformation($"Trying to delete an object with id {id} from the db");
            DbContext.Set<T>().Remove(GetOne(id));
        }

        public void Update(T item)
        {
            Logger.LogInformation("Updating an object");
            DbContext.Set<T>().Attach(item);
            DbContext.Entry(item).State = EntityState.Modified;
        }
    }
}