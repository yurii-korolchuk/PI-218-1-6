using DAL.Dependencies;
using DAL.Models;
using DAL.Repository;
using Ninject;

namespace StartDataBase
{
    class Program
    {
        static void Main(string[] args)
        {
            var kernel = new StandardKernel(new DataAccessModule());

            var data = kernel.Get<IUnitOfWork>();

            data.Users.Create(new User { Login = "Admin", Pass = "Admin", RoleName = "Admin" });
            data.Users.Create(new User { Login = "Manager", Pass = "Manager", RoleName = "Manager" });
            data.Users.Create(new User { Login = "User", Pass = "User", RoleName = "User" });
            data.Users.Create(new User { Login = "Guest", Pass = "Guest", RoleName = "Guest" });
            data.Save();

            data.Services.Create(new Service { Name = "ServiceName", Price = "500", Type = "ServiceForSomething" });
            data.Save();
        }
    }
}
