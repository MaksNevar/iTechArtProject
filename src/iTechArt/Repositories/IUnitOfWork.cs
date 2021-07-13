using System;

namespace iTechArt.Repositories
{
    internal interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}