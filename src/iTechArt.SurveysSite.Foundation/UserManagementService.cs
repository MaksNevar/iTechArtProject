using iTechArt.SurveysSite.DomainModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using iTechArt.SurveysSite.Repositories.UnitOfWorks;

namespace iTechArt.SurveysSite.Foundation
{
    public class UserManagementService : IUserManagementService
    {
        private readonly UserManager<User> _userManager;
        private readonly ISurveysSiteUnitOfWork _unitOfWork;


        public UserManagementService(UserManager<User> userManager, ISurveysSiteUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }


        public async Task<User> GetUserByUsernameAsync(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentNullException(nameof(userName), "Username cannot be null");
            }

            var user = await _userManager.FindByNameAsync(userName);

            return user;
        }

        public async Task<IReadOnlyCollection<User>> GetAllUsersAsync()
        {
            var users = await _unitOfWork.UserRepository.GetAllUsersAsync();

            return users;
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);

            _unitOfWork.UserRepository.Delete(user);
            await _unitOfWork.SaveAsync();
        }
    }
}