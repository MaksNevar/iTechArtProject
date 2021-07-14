using iTechArt.SurveysSite.DomainModel;
using iTechArt.SurveysSite.Repositories;
using System;

namespace iTechArt.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ButtonClicksCounterContext _context;

        private bool _disposed;
        public Repository<ButtonClicksCounter> Repository { get; set; }

        public UnitOfWork(ButtonClicksCounterContext context, Repository<ButtonClicksCounter> repository)
        {
            _context = context;
            Repository = repository;
        }
        

        public virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _context.SaveChanges();
        }


    }
}