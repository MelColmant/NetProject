using API_FT.Models;
using API_FT.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace API_FT.Controllers
{
    [RoutePrefix("api")]
    public class ParentChildController : ApiController
    {
        private ParentChildService _service = new ParentChildService();

        [AcceptVerbs("POST")]
        [Route("ParentChild")]
        public void Register(ParentChild parentchild)
        {
            _service.Add(parentchild);
        }

        [AcceptVerbs("DELETE")]
        [Route("ParentChild/{id}")]
        public void Remove(int id)
        {
            _service.Delete(id);
        }

        [AcceptVerbs("GET")]
        [Route("ParentChild")]
        public IEnumerable<ParentChild> RetrieveAll()
        {
            return _service.Get();
        }

        [AcceptVerbs("GET")]
        [Route("ParentChild/{id}")]
        public ParentChild Retrieve(int id)
        {
            return _service.Get(id);
        }

        [AcceptVerbs("PUT")]
        [Route("ParentChild/{id}")]
        public void Update(int id, ParentChild parentchild)
        {
            _service.Update(id, parentchild);
        }
    }
}