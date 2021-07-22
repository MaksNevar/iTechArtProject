using System.Linq;
using System.Threading.Tasks;
using iTechArt.SurveysSite.DomainModel;
using Microsoft.EntityFrameworkCore;

namespace iTechArt.Common
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly DbContext _dbContext;
        protected readonly ILog _logger;


        public Repository(DbContext context, ILog logger)
        {
            _dbContext = context;
            _logger = logger;
        }


        public void Create(TEntity item)
        {
            _logger.LogInformation("Creating a new object with repository");

            _dbContext.Set<TEntity>().Add(item);
        }

        public async Task<IQueryable<TEntity>> GetAllAsync()
        {
            _logger.LogInformation("Getting all instances of the entity");

            return (await _dbContext.Set<TEntity>().ToListAsync()).AsQueryable();
        }

        public async Task<TEntity> GetByIdAsync(object id)
        {
            _logger.LogInformation($"Trying to find an object with id {id} in the db");

            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public void Delete(TEntity item)
        {
            _logger.LogInformation($"Trying to delete an object {item} from the db");

            _dbContext.Set<TEntity>().Remove(item);
        }


        public void Update(TEntity item)
        {
            _logger.LogInformation($"Updating an object {item}");

            _dbContext.Set<TEntity>().Update(item);
        }
    }
}