using System;
using System.Threading;
using System.Threading.Tasks;
using iTechArt.Common;
using iTechArt.SurveysSite.DomainModel;
using iTechArt.SurveysSite.Repositories.UnitOfWorks;
using Microsoft.AspNetCore.Identity;

namespace iTechArt.SurveysSite.Repositories.Stores
{
    [UsedImplicitly]
    public class RoleStore : IRoleStore<Role>
    {
        private readonly ISurveysSiteUnitOfWork _unitOfWork;


        public RoleStore(ISurveysSiteUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public async Task<IdentityResult> CreateAsync(Role role, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (role == null)
            {
                throw new ArgumentNullException(nameof(role), "Role can't be null");
            }

            _unitOfWork.RoleRepository.Create(role);
            await _unitOfWork.SaveAsync();

            return IdentityResult.Success;
        }

        public async Task<IdentityResult> UpdateAsync(Role role, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (role == null)
            {
                throw new ArgumentNullException(nameof(role), "Role does not exist");
            }

            _unitOfWork.RoleRepository.Update(role);
            await _unitOfWork.SaveAsync();

            return IdentityResult.Success;
        }

        public async Task<IdentityResult> DeleteAsync(Role role, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (role == null)
            {
                throw new ArgumentNullException(nameof(role), "Role does not exist");
            }

            _unitOfWork.RoleRepository.Delete(role);
            await _unitOfWork.SaveAsync();

            return IdentityResult.Success;
        }

        public Task<string> GetRoleIdAsync(Role role, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (role == null)
            {
                throw new ArgumentNullException(nameof(role), "Role does not exist");
            }

            return Task.FromResult(role.Id.ToString());
        }

        public Task<string> GetRoleNameAsync(Role role, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (role == null)
            {
                throw new ArgumentNullException(nameof(role), "Role does not exist");
            }

            return Task.FromResult(role.Name);
        }

        public Task SetRoleNameAsync(Role role, string roleName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (role == null)
            {
                throw new ArgumentNullException(nameof(role), "Role does not exist");
            }

            role.Name = roleName;

            return Task.CompletedTask;
        }

        public Task<string> GetNormalizedRoleNameAsync(Role role, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (role == null)
            {
                throw new ArgumentNullException(nameof(role), "Role does not exist");
            }

            var normalizedName = role.NormalizedName;

            return Task.FromResult(normalizedName);
        }

        public Task SetNormalizedRoleNameAsync(Role role, string normalizedName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (role == null)
            {
                throw new ArgumentNullException(nameof(role), "Role does not exist");
            }

            role.NormalizedName = normalizedName;

            return Task.CompletedTask;
        }

        public async Task<Role> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (!int.TryParse(roleId, out var id))
            {
                throw new InvalidCastException("Role id is not valid");
            }

            var role = await _unitOfWork.RoleRepository.GetByIdAsync(id);

            return role;
        }

        public async Task<Role> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var role = await _unitOfWork.RoleRepository.GetRoleByNameAsync(normalizedRoleName);

            return role;
        }
    }
}