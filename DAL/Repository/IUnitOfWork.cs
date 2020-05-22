using DAL.Models;

namespace DAL.Repository
{
    public interface IUnitOfWork
    {
        IGenericRepository<User> Users { get; set; }

        IGenericRepository<Service> Services { get; set; }

        void Save();

        void Dispose();
    }
}
