using System;
using System.Threading.Tasks;
using iTechArt.SurveysSite.DomainModel;

namespace iTechArt.Common
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity;
        Task SaveAsync();
    }
}