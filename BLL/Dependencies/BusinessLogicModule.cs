using BLL.Logic;
using DAL.Dependencies;
using DAL.Repository;
using Ninject;
using Ninject.Modules;

namespace BLL.Dependencies
{
    public class BusinessLogicModule : NinjectModule
    {
        public override void Load()
        {
            var unitOfWork = new StandardKernel(new DataAccessModule()).Get<IUnitOfWork>();
            Bind<IServiceActions>().ToConstructor(x => new ServiceActions(unitOfWork));
            Bind<IUserActions>().ToConstructor(x => new UserActions(unitOfWork));
        }
    }
}
