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
    public class GodFMController : ApiController
    {
        private GodFMService _service = new GodFMService();

        [AcceptVerbs("POST")]
        [Route("GodFM")]
        public void Register(GodFM godfm)
        {
            _service.Add(godfm);
        }

        [AcceptVerbs("DELETE")]
        [Route("GodFM/{id}")]
        public void Remove(int id)
        {
            _service.Delete(id);
        }

        [AcceptVerbs("GET")]
        [Route("GodFM")]
        public IEnumerable<GodFM> RetrieveAll()
        {
            return _service.Get();
        }

        [AcceptVerbs("GET")]
        [Route("GodFM/{id}")]
        public GodFM Retrieve(int id)
        {
            return _service.Get(id);
        }

        [AcceptVerbs("PUT")]
        [Route("GodFM/{id}")]
        public void Update(int id, GodFM godfm)
        {
            _service.Update(id, godfm);
        }
    }
}