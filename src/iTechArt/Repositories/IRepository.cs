using System.Collections.Generic;

namespace iTechArt.Repositories
{
    internal interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetOne(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}