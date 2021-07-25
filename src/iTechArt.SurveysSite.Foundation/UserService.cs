using System.Collections.Generic;
using System.Threading.Tasks;
using iTechArt.SurveysSite.DomainModel;
using iTechArt.SurveysSite.Repositories.UnitOfWorks;

namespace iTechArt.SurveysSite.Foundation
{
    public class UserService : IUserService
    {
        private readonly IUserUnitOfWork _unitOfWork;


        public UserService(IUserUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<IReadOnlyCollection<User>> GetAllUsersAsync()
        {
            return await _unitOfWork.UserRepository.GetAllAsync();
        }

        public async Task CreateUser(User userToCreate)
        {
            _unitOfWork.UserRepository.Create(userToCreate);
            await _unitOfWork.SaveAsync();
        }
    }
}