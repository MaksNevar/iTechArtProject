using System.Threading.Tasks;
using iTechArt.Repositories.UnitOfWork;
using iTechArt.SurveysSite.DomainModel;
using iTechArt.SurveysSite.Repositories.UnitOfWorks;
using Microsoft.AspNet.Identity;

namespace iTechArt.SurveysSite.Repositories
{
    public class UserStore : IUserStore<User, int>
    {
        private readonly ISurveysSiteUnitOfWork _unitOfWork;


        public UserStore(ISurveysSiteUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public Task CreateAsync(User user)
        {
            _unitOfWork.UserRepository.Create(user);

            return Task.FromResult<object>(null);
        }

        public Task UpdateAsync(User user)
        {
            _unitOfWork.UserRepository.Update(user);

            return Task.FromResult<object>(null);
        }

        public Task DeleteAsync(User user)
        {
            _unitOfWork.UserRepository.Delete(user);

            return Task.FromResult<object>(null);
        }

        public async Task<User> FindByIdAsync(int userId)
        {
            return await _unitOfWork.UserRepository.GetByIdAsync(userId);
        }

        public async Task<User> FindByNameAsync(string userName)
        {
            return await _unitOfWork.UserRepository.GetByNameAsync(userName);
        }
    }
}