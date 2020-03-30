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
    public class Person_RessourceController : ApiController
    {
        private Person_RessourceService _service = new Person_RessourceService();

        [AcceptVerbs("POST")]
        [Route("Person_Ressource")]
        public void Register(Person_Ressource personressource)
        {
            _service.Add(personressource);
        }

        [AcceptVerbs("DELETE")]
        [Route("Person_Ressource/{id}")]
        public void Remove(int id)
        {
            _service.Delete(id);
        }

        [AcceptVerbs("GET")]
        [Route("Person_Ressource")]
        public IEnumerable<Person_Ressource> RetrieveAll()
        {
            return _service.Get();
        }

        [AcceptVerbs("GET")]
        [Route("Person_Ressource/{id}")]
        public Person_Ressource Retrieve(int id)
        {
            return _service.Get(id);
        }

        [AcceptVerbs("PUT")]
        [Route("Person_Ressource/{id}")]
        public void Update(int id, Person_Ressource personressource)
        {
            _service.Update(id, personressource);
        }
    }
}
