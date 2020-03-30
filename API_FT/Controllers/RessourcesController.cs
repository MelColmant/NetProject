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
    public class RessourcesController : ApiController
    {
        private RessourcesService _service = new RessourcesService();

        [AcceptVerbs("POST")]
        [Route("Ressources")]
        public void Register(Ressources ressource)
        {
            _service.Add(ressource);
        }

        [AcceptVerbs("DELETE")]
        [Route("Ressources/{id}")]
        public void Remove(int id)
        {
            _service.Delete(id);
        }

        [AcceptVerbs("GET")]
        [Route("Ressources")]
        public IEnumerable<Ressources> RetrieveAll()
        {
            return _service.Get();
        }

        [AcceptVerbs("GET")]
        [Route("Ressources/{id}")]
        public Ressources Retrieve(int id)
        {
            return _service.Get(id);
        }

        [AcceptVerbs("PUT")]
        [Route("Ressources/{id}")]
        public void Update(int id, Ressources ressource)
        {
            _service.Update(id, ressource);
        }
    }
}