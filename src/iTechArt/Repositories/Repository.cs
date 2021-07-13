using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace iTechArt.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext dbContext;
        protected readonly ILogger logger;


        public Repository(DbContext context, ILogger logger)
        {
            dbContext = context;
            this.logger = logger;
        }


        public void Create(T item)
        {
            logger.LogInformation("Creating a new object with repository");
            dbContext.Set<T>().Add(item);
        }

        public IEnumerable<T> GetAll()
        {
            logger.LogInformation("Getting all instances of the entity");

            return dbContext.Set<T>().ToList();
        }

        public T GetOne(int id)
        {
            logger.LogInformation($"Trying to find an object with id {id} in the db");

            return dbContext.Set<T>().Find(id);
        }

        public void Delete(int id)
        {
            logger.LogInformation($"Trying to delete an object with id {id} from the db");
            dbContext.Set<T>().Remove(GetOne(id));
        }

        public void Update(T item)
        {
            logger.LogInformation("Updating an object");
            dbContext.Set<T>().Attach(item);
            dbContext.Entry(item).State = EntityState.Modified;
        }
    }
}