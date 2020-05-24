using BLL.Logic;
using System.Collections.Generic;
using System.Web.Http;

namespace Course_6.Controllers
{
    public class BuyController : ApiController
    {
        private readonly IServiceActions _service;

        public BuyController(IServiceActions service)
        {
            _service = service;
        }

        // GET: api/Buy
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Buy/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Buy
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Buy/5
        public void Put(int id, [FromBody]int serviceId)
        {
            _service.SellService(id, serviceId);
        }

        // DELETE: api/Buy/5
        public void Delete(int id)
        {
        }
    }
}
