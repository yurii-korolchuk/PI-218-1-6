using BLL.Logic;
using System.Collections.Generic;
using System.Web.Http;
using BLL.DTO;

namespace Course_6.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IUserActions _service;

        public UsersController(IUserActions service)
        {
            _service = service;
        }

        // GET: api/Users
        public IEnumerable<UserDto> Get()
        {
            return _service.GetUsers();
        }

        // GET: api/Users/5
        public UserDto Get(int id)
        {
            return _service.GetUserByID(id);
        }

        // POST: api/Users
        public void Post([FromBody]UserDto user)
        {
            _service.AddUser(user);
        }

        // PUT: api/Users/5
        public void Put(int id, [FromBody]UserDto user)
        {
            _service.Updateuser(id, user);
        }

        // DELETE: api/Users/5
        public void Delete(int id)
        {
            _service.RemoveUserByID(id);
        }
    }
}
