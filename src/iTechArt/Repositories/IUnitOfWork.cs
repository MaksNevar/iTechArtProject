using System;

namespace iTechArt.Repositories
{
    interface IUnitOfWork : IDisposable
    {
        int Save();
    }
}
