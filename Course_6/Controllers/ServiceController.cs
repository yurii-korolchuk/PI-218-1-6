using BLL.Logic;
using System.Collections.Generic;
using System.Web.Http;
using BLL.DTO;

namespace Course_6.Controllers
{
    public class ServiceController : ApiController
    {
        private readonly IServiceActions _service;

        public ServiceController(IServiceActions service)
        {
            _service = service;
        }

        // GET: api/Service
        public IEnumerable<ServiceDto> Get()
        {
            return _service.GetServices();
        }

        // GET: api/Service/5
        public ServiceDto Get(int id)
        {
            return _service.GetServiceByID(id);
        }

        // POST: api/Service
        public void Post([FromBody]ServiceDto service)
        {
            _service.AddService(service);
        }

        // PUT: api/Service/5
        public void Put(int id, [FromBody]ServiceDto service)
        {
            _service.UpdateService(id, service);
        }

        // DELETE: api/Service/5
        public void Delete(int id)
        {
            _service.RemoveServiceByID(id);
        }
    }
}
