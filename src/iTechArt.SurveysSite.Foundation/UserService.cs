using System.Collections.Generic;
using System.Threading.Tasks;
using iTechArt.SurveysSite.DomainModel;
using iTechArt.SurveysSite.Repositories.UnitOfWorks;

namespace iTechArt.SurveysSite.Foundation
{
    public class UserService : IUserService
    {
        private readonly ISurveysSiteUnitOfWork _unitOfWork;


        public UserService(ISurveysSiteUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<IReadOnlyCollection<User>> GetAllUsersAsync()
        {
            var userRepository = _unitOfWork.GetRepository<User>();

            return await userRepository.GetAllAsync();
        }

        public async Task CreateUserAsync(User userToCreate)
        {
            var userRepository = _unitOfWork.GetRepository<User>();

            userRepository.Create(userToCreate);
            await _unitOfWork.SaveAsync();
        }
    }
}