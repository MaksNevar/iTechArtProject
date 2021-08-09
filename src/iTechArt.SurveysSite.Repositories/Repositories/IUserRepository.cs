using System.Threading.Tasks;
using iTechArt.Repositories.Repository;
using iTechArt.SurveysSite.DomainModel;

namespace iTechArt.SurveysSite.Repositories.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByNameAsync(string normalizedUserName);
    }
}