using DAL.Models;
using DAL.Repository;
using Ninject.Modules;

namespace DAL.Dependencies
{
    public class DataAccessModule : NinjectModule
    {
        public override void Load()
        {
            var agencyContext = new Context();

            Bind<IGenericRepository<User>>().ToConstructor(x => new GenericRepository<User>(agencyContext));
            Bind<IGenericRepository<Service>>().ToConstructor(x => new GenericRepository<Service>(agencyContext));

            Bind<IUnitOfWork>().ToConstructor
                (x => new UnitOfWork(agencyContext, x.Inject<IGenericRepository<User>>(), x.Inject<IGenericRepository<Service>>()));
        }
    }
}
