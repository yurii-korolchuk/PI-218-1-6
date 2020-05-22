using DAL.Models;
using System.Data.Entity;

namespace DAL
{
    internal class Context : DbContext
    {
        public Context() : base("name=MyCourseWork_6")
        {
        }

        public IDbSet<User> Users { get; set; }

        public IDbSet<Service> Services { get; set; }
    }
}
