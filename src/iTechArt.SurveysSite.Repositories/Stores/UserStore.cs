using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using iTechArt.Common;
using iTechArt.SurveysSite.DomainModel;
using iTechArt.SurveysSite.Repositories.UnitOfWorks;
using Microsoft.AspNetCore.Identity;

namespace iTechArt.SurveysSite.Repositories.Stores
{
    [UsedImplicitly]
    public class UserStore : IUserPasswordStore<User>, IUserRoleStore<User>
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

        public Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User does not exist");
            }

            return Task.FromResult(user.Id.ToString());
        }

        public Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User does not exist");
            }

            return Task.FromResult(user.UserName);
        }

        public Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User does not exist");
            }

            user.UserName = userName;

            return Task.CompletedTask;
        }

        public Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User does not exist");
            }

            return Task.FromResult(user.NormalizedUserName);
        }

        public Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User does not exist");
            }

            user.NormalizedUserName = normalizedName;

            return Task.CompletedTask;
        }

        public async Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User can't be null");
            }

            _unitOfWork.UserRepository.Create(user);
            await _unitOfWork.SaveAsync();

            return IdentityResult.Success;
        }

        public async Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User does not exist");
            }

            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.SaveAsync();

            return IdentityResult.Success;
        }

        public async Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User does not exist");
            }

            _unitOfWork.UserRepository.Delete(user);
            await _unitOfWork.SaveAsync();

            return IdentityResult.Success;
        }

        public async Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (!int.TryParse(userId, out var id))
            {
                throw new InvalidCastException("User id is not valid");
            }

            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);

            return user;
        }

        public async Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var user = await _unitOfWork.UserRepository.GetUserByNameAsync(normalizedUserName);

            return user;
        }

        public Task SetPasswordHashAsync(User user, string passwordHash, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User does not exist");
            }

            user.PasswordHash = passwordHash;

            return Task.CompletedTask;
        }

        public Task<string> GetPasswordHashAsync(User user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User does not exist");
            }

            var passwordHash = user.PasswordHash;

            return Task.FromResult(passwordHash);
        }

        public Task<bool> HasPasswordAsync(User user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User does not exist");
            }

            return Task.FromResult(user.PasswordHash != null);
        }

        public async Task AddToRoleAsync(User user, string normalizedRoleName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User does not exist");
            }

            if (string.IsNullOrWhiteSpace(normalizedRoleName))
            {
                throw new ArgumentNullException(nameof(normalizedRoleName), "Role name is not valid");
            }

            var role = await _unitOfWork.RoleRepository.GetRoleByNameAsync(normalizedRoleName);

            if (role == null)
            {
                throw new ArgumentNullException(nameof(role), "Role does not exist");
            }

            var userRole = new UserRole
            {
                UserId = user.Id,
                RoleId = role.Id
            };

            _unitOfWork.GetRepository<UserRole>().Create(userRole);
            await _unitOfWork.SaveAsync();
        }

        public async Task RemoveFromRoleAsync(User user, string normalizedRoleName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User does not exist");
            }

            if (string.IsNullOrWhiteSpace(normalizedRoleName))
            {
                throw new ArgumentNullException(nameof(normalizedRoleName), "Role name is not valid");
            }

            var role = await _unitOfWork.RoleRepository.GetRoleByNameAsync(normalizedRoleName);

            if (role == null)
            {
                throw new ArgumentNullException(nameof(role), "Role does not exist");
            }

            var userRole = await _unitOfWork.GetRepository<UserRole>().GetByIdAsync(user.Id, role.Id);
            _unitOfWork.GetRepository<UserRole>().Delete(userRole);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IList<string>> GetRolesAsync(User user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User does not exist");
            }

            var roleNames = await _unitOfWork.UserRepository.GetUserRolesAsync(user.Id);

            return roleNames.ToList();
        }

        public async Task<bool> IsInRoleAsync(User user, string normalizedRoleName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User does not exist");
            }

            if (string.IsNullOrEmpty(normalizedRoleName))
            {
                throw new ArgumentNullException(nameof(normalizedRoleName), "Role name is not valid");
            }

            var role = await _unitOfWork.RoleRepository.GetRoleByNameAsync(normalizedRoleName);

            if (role == null)
            {
                throw new ArgumentNullException(nameof(role), "Role does not exist");
            }

            var userRole = await _unitOfWork.GetRepository<UserRole>().GetByIdAsync(user.Id, role.Id);

            return userRole != null;
        }

        public async Task<IList<User>> GetUsersInRoleAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (string.IsNullOrEmpty(normalizedRoleName))
            {
                throw new ArgumentNullException(nameof(normalizedRoleName), "Role name is not valid");
            }

            var role = await _unitOfWork.RoleRepository.GetRoleByNameAsync(normalizedRoleName);

            if (role == null)
            {
                throw new ArgumentNullException(nameof(role), "Role does not exist");
            }

            var users = await _unitOfWork.RoleRepository.GetUsersInRoleAsync(role.Id);

            return users.ToList();
        }
    }
}