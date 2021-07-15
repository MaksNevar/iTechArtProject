using System;
using System.Threading.Tasks;

namespace iTechArt.Common
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> Save();
    }
}