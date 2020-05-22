using DAL.Models;
using System;

namespace DAL.Repository
{
    internal class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly Context _context;

        public IGenericRepository<User> Users { get; set; }

        public IGenericRepository<Service> Services { get; set; }

        private bool _isDisposed;

        public UnitOfWork(Context context, IGenericRepository<User> users, IGenericRepository<Service> services)
        {
            _context = context;
            Users = users;
            Services = services;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed) return;
            if (disposing)
            {
                _context.Dispose();
            }

            _isDisposed = true;
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
