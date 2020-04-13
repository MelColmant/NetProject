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
    public class PersonController : ApiController
    {
        private PersonService _service = new PersonService();

        [AcceptVerbs("POST")]
        [Route("Person")]
        public void Register(Person person)
        {
            _service.Add(person);
        }

        [AcceptVerbs("POST")]
        [Route("PersonWithId")]
        public int RegisterWithId(Person person)
        {
           return _service.AddWithId(person);
        }

        [AcceptVerbs("DELETE")]
        [Route("Person/{id}")]
        public void Remove(int id)
        {
            _service.Delete(id);
        }

        [AcceptVerbs("GET")]
        [Route("Person")]
        public IEnumerable<Person> RetrieveAll()
        {
            return _service.Get();
        }

        [AcceptVerbs("GET")]
        [Route("Person/{id}")]
        public Person Retrieve(int id)
        {
            return _service.Get(id);
        }

        [AcceptVerbs("PUT")]
        [Route("Person/{id}")]
        public void Update(int id, Person person)
        {
            _service.Update(id, person);
        }

        [AcceptVerbs("GET")]
        [Route("Person/AllTree/{id}")]
        public IEnumerable<Person> RetrieveAllFromTree(int id)
        {
            return _service.GetAllFromTree(id);
        }

        [AcceptVerbs("GET")]
        [Route("Person/Children/{id}")]
        public IEnumerable<Person> RetrieveChildren(int id)
        {
            return _service.GetChildren(id);
        }

        [AcceptVerbs("GET")]
        [Route("Person/Children/{id1}/{id2}")]
        public IEnumerable<Person> RetrieveChildrenRel(int id1, int id2)
        {
            return _service.GetChildrenRel(id1, id2);
        }

        [AcceptVerbs("GET")]
        [Route("Person/Parents/{id}")]
        public IEnumerable<Person> RetrieveParents(int id)
        {
            return _service.GetParents(id);
        }

        [AcceptVerbs("GET")]
        [Route("Person/Siblings/{id}")]
        public IEnumerable<Person> RetrieveSiblings(int id)
        {
            return _service.GetSiblings(id);
        }
    }
}